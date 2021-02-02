using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Security.Authorization;
using Tests.Security.Options;

namespace Tests.Security
{
    public static class Bootstrap
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            MainContext context = new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING"));

            JwtOption jwtOption =
                JsonConvert.DeserializeObject<JwtOption>(context.GlobalSetting
                    .FirstOrDefault(x => x.Key == "JwtOption")?.StringValue ?? throw new Exception("Can't find JwtOption setting"));

            if (jwtOption == null) throw new ApplicationException("Can't configure authorize jwt options");

            AuthOption.SetAuthOption(jwtOption.Issuer, jwtOption.Audience, jwtOption.Key, jwtOption.Lifetime);

            List<Role> roleList = context.Role.ToList();
            foreach (var t in roleList)
            {
                services.AddAuthorizationCore(options =>
                {
                    options.AddPolicy(t.Title, policy =>
                        policy.Requirements.Add(new RoleEntryRequirement(t.Id)));
                });
            }

            services.AddSingleton<IAuthorizationHandler, RoleEntryHandler>();

            return services;
        }
    }
}
