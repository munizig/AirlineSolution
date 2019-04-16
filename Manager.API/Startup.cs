using AutoMapper;
using FluentValidation.AspNetCore;
using Manager.API.Configurations;
using Manager.API.Middleware;
using Manager.Application.AutoMapper;
using Manager.Application.Logger;
using Manager.Application.Services;
using Manager.Domain.Repositories;
using Manager.Domain.Services;
using Manager.Logger;
using Manager.Persistence.Context;
using Manager.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace Manager.API
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
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Formatting = Formatting.Indented;
                })
                .AddFluentValidation();

            RegisterSwagger(services);
            RegisterAutoMapper(services);
            RegisterEntityFramework(services);
            RegisterCompression(services);
            RegisterDependencies(services);

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<JsonUnhandledExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseMvc();
            app.UseStatusCodePages();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airline API V1");
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services.AddSingleton<IApplicationLogger, ApplicationLogger>();

            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IAirplaneService, AirplaneService>();
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "Airline API",
                    Description = "API created to manage Airline's information.",
                    Version = "v1"
                });
            });

        }

        private void RegisterEntityFramework(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddDbContext<AirlineContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AirlineDB")));
        }

        private void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper();
            AutoMapperConfig.RegisterMappings();
        }

        private void RegisterCompression(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.EnableForHttps = true;
                options.MimeTypes =
                    Microsoft.AspNetCore.ResponseCompression.ResponseCompressionDefaults.MimeTypes.Concat(new[] {
                    "application/javascript",
                    "text/css",
                    "text/plain",
                    "image/svg+xml",
                });
            });
        }
    }
}
