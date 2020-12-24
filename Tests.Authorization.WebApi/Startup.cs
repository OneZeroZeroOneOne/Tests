using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Bll.DescribeDependency;
using Tests.Bll.Services;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Security.Options;
using Tests.Utilities.Middlewares;

namespace Tests.Authorization.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            MainContext context = new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING") ?? "Host=104.248.250.163;Database=postgres;Username=postgres;Password=123456asdfg");

            JwtOption jwtOption = context.JwtOption.FirstOrDefault();

            AuthOption.SetAuthOption(jwtOption.Issuer, jwtOption.Audience, jwtOption.Key, jwtOption.Lifetime);

            services.AddNotificationSender();

            services.AddTransient<RegisterService>();

            services.AddScoped(x => new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING") ?? "Host=104.248.250.163;Database=postgres;Username=postgres;Password=123456asdfg"));

            services.AddTransient<LoginService>();

            services.AddTransient<UserService>();

            services.AddTransient<NotificationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            //app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin());
            app.UseCors(x => x.AllowAnyHeader());

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            var options = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };

            app.UseForwardedHeaders(options);

            if (env.IsDevelopment())
            {
                app.UseSwagger();
            }
            else
            {
                var basePath = "/api/authorization";
                app.UseSwagger(c => c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer>
                        {new OpenApiServer {Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{basePath}"}};
                }));
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
                c.InjectJavascript("https://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js");
                c.InjectJavascript("https://unpkg.com/browse/webextension-polyfill@0.6.0/dist/browser-polyfill.min.js", type: "text/html");
                c.InjectJavascript("https://raw.githack.com/OneZeroZeroOneOne/StaticFiles/master/LoginTests.js");
            });
        }
    }
}
