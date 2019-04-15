using AutoMapper;
using FluentValidation.AspNetCore;
using Manager.Application.Services;
using Manager.Domain.Repositories;
using Manager.Domain.Services;
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

			services
				.AddAutoMapper();

			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new Info
				{
					Title = "Airline API",
					Description = "API created to manage information in an Airline.",
					Version = "v1"
				});
			});

			services.AddEntityFrameworkSqlServer();
			services.AddDbContext<AirlineContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("AirlineDB")));

			RegisterDependencies(services);
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if(env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
			app.UseStatusCodePages();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airline API V1");
			});

		}

		public void RegisterDependencies(IServiceCollection services)
		{
			services.AddScoped<IAirplaneRepository, AirplaneRepository>();
			services.AddScoped<IAirplaneService, AirplaneService>();
		}
	}
}
