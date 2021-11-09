using AutoMapper;
using CustomerService.BusinessLogic.Contexts;
using CustomerService.BusinessLogic.Validators;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NATS.Client;
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
            return services.AddTransient(_ =>
            {
                var factory = new ConnectionFactory();
                var options = ConnectionFactory.GetDefaultOptions();
                options.Url = configuration.GetConnectionString("NatsConnection");
                return factory.CreateConnection();
            })
            .AddTransient<INatsService, NatsService>()
            .Configure<NatsOptions>(configuration.GetSection("Nats"));;
        }
    }
}