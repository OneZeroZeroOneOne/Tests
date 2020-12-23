using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tests.Bll.Services;
using Tests.Dal;
using Tests.Dal.Contexts;
using Tests.Dal.Models;
using Tests.Security.Authorization;
using Tests.Security.Options;
using Tests.Utilities.Middlewares;

namespace Tests.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            MainContext context = new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING"));

            services.AddScoped(x => new MainContext(Environment.GetEnvironmentVariable("DATABASECONNECTIONSTRING")));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            JwtOption jwtOption = context.JwtOption.FirstOrDefault();

            if (jwtOption == null) throw new ApplicationException("Can't configure authorize jwt options");

            AuthOption.SetAuthOption(jwtOption.Issuer, jwtOption.Audience, jwtOption.Key, jwtOption.Lifetime);

            List<Role> roleList = context.Role.ToList();
            foreach (var t in roleList)
            {
                services.AddAuthorization(options =>
                {
                    options.AddPolicy(t.Title, policy =>
                        policy.Requirements.Add(new RoleEntryRequirement(t.Id)));
                });
            }
            services.AddSingleton<IAuthorizationHandler, RoleEntryHandler>();

            services.AddTransient<EmployeeService>();

            services.AddTransient<ResumeService>();

            services.AddTransient<AvatarService>();

            services.AddTransient<VacancyService>();

            services.AddTransient<PositionService>();

            services.AddScoped(x =>
            {
                var a = new AttachmentPathProvider();
                a.ConfigurePath();
                return a;
            });

            services.AddTransient<QuizService>();
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                        {

                            ValidateIssuer = true,

                            ValidIssuer = AuthOption.ISSUER,


                            ValidateAudience = true,

                            ValidAudience = AuthOption.AUDIENCE,

                            ValidateLifetime = true,


                            IssuerSigningKey = AuthOption.GetSymmetricSecurityKey(),

                            ValidateIssuerSigningKey = true,
                        };
                    });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AttachmentPathProvider attachmentPathProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();
            if (env.IsDevelopment())
            {
                
            }
            else
            {
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(Path.Combine(attachmentPathProvider.GetPath(), "Files")),
                    RequestPath = new PathString("/Files")
                });
            }
            

            app.UseCors(x => x.AllowAnyOrigin());

            app.UseCors(x => x.AllowAnyHeader());

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
            }
            else
            {
                var basePath = "/api/management";
                app.UseSwagger(c => c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer>
                        {
                            new OpenApiServer {Url = $"{httpReq.Scheme}s://{httpReq.Host.Value}{basePath}"},
                        };
                }));
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.InjectJavascript("https://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js");
                c.InjectJavascript("https://unpkg.com/browse/webextension-polyfill@0.6.0/dist/browser-polyfill.min.js", type: "text/html");
                c.InjectJavascript("https://raw.githack.com/OneZeroZeroOneOne/StaticFiles/master/LoginTests.js");
            });
        }
    }
}
