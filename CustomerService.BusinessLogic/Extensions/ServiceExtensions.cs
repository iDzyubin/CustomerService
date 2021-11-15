using AutoMapper;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.BusinessLogic.Handlers;
using CustomerService.BusinessLogic.Models;
using CustomerService.BusinessLogic.Proxies;
using CustomerService.BusinessLogic.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
using NatsExtensions.Extensions;
using NatsExtensions.Options;
using NatsExtensions.Services;

namespace CustomerService.BusinessLogic.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddDbContext<CustomerContext>(builder => 
                builder.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("CustomerService.BusinessLogic")));
        }
        
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            return services.AddFluentValidation(configuration =>
            {
                configuration.RegisterValidatorsFromAssemblyContaining<AnchorValidator>();
                configuration.ImplicitlyValidateChildProperties = true;
                configuration.ImplicitlyValidateRootCollectionElements = true;
                configuration.DisableDataAnnotationsValidation = true;
            });
        }
        
        public static IServiceCollection AddAutomapper(this IServiceCollection services)
        {
            return services.AddSingleton(
                new MapperConfiguration(configuration => 
                        configuration.AddMaps("CustomerService.BusinessLogic"))
                    .CreateMapper());
        }
        
        public static IServiceCollection AddNats(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddNatsExtensions(builder =>
            {
                builder.Subject = configuration.GetSection("Nats")["Subject"];
                builder.ConnectionString = configuration.GetConnectionString("NatsConnection");
            })
            .AddNatsHandlers()
            .AddNatsProxies();
        }
        
        private static IServiceCollection AddNatsHandlers(this IServiceCollection services) =>
            services.AddNatsHandler<
                GetCustomersRequest, 
                GetCustomersReply, 
                GetCustomersHandler>();
        
        private static IServiceCollection AddNatsProxies(this IServiceCollection services) =>
            services.AddNatsProxy<
                GetOrdersByCustomerIdRequest, 
                GetOrdersByCustomerIdReply,
                OrderServiceProxy>();
    }
}