using System;
using System.Linq;
using AutoMapper;
using Mailjet.Client;
using Microsoft.Extensions.DependencyInjection;
using Tests.Dal;
using Tests.Dal.Contexts;

namespace Tests.Utilities
{
    public static class Bootstrap
    {
        public static IServiceCollection AddDefaults(this IServiceCollection services)
        {
            services.AddScoped(x => new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING")));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddEmailClient(this IServiceCollection services)
        {
            services.AddScoped(x =>
            {
                MainContext context = new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING"));

                return new MailjetClient((context.GlobalSetting.FirstOrDefault(x => x.Key == "MailjetApiKey")).StringValue, (context.GlobalSetting.FirstOrDefault(x => x.Key == "MailjetApiSecret")).StringValue);
            });

            return services;
        }
    }
}
