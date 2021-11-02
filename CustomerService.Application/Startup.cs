using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.BusinessLogic.Validators;
using CustomerService.Contract.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CustomerService.Application
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
            services.AddTransient<ICustomerService, BusinessLogic.Services.CustomerService>();
            
            services.AddDbContext<ApplicationDbContext>(builder => 
                builder.UseNpgsql(
                    Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("CustomerService.BusinessLogic")));

            services.AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<AnchorValidator>();
                configuration.ImplicitlyValidateChildProperties = true;
                configuration.ImplicitlyValidateRootCollectionElements = true;
                configuration.DisableDataAnnotationsValidation = true;
            });

            var mapperConfiguration = new MapperConfiguration(configuration => 
                configuration.AddMaps("CustomerService.BusinessLogic"));
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CustomerService.Application", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Create db after start application
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.EnsureCreated();
            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CustomerService.Application v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}