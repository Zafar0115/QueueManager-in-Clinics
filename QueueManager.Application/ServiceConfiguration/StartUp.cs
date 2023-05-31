using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QueueManager.Application.FluentValidation;
using QueueManager.Application.Mappings;
using QueueManager.Domain.Models.BusinessModels;
using System.Reflection;

namespace QueueManager.Application.ServiceConfiguration
{
    public static class StartUp
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(AppMappingProfile));

            return services;
        }
    }
}
