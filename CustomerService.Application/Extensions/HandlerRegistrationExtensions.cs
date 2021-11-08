using CustomerService.Application.Handlers;
using CustomerService.BusinessLogic.Models;
using Microsoft.Extensions.DependencyInjection;
using NatsExtensions.Handlers;
using NatsExtensions.HostedServices;

namespace CustomerService.Application.Extensions
{
    public static class HandlerRegistrationExtensions
    {
        public static IServiceCollection AddHandlersToHost(this IServiceCollection services)
        {
            services.AddHandlers();
            
            services.AddHostedService<RegisterHandlerService<GetCustomersRequest, GetCustomersReply>>();
            
            return services;
        }
        
        private static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IHandler<GetCustomersRequest, GetCustomersReply>, GetCustomersHandler>();
            return services;
        }
    }
}