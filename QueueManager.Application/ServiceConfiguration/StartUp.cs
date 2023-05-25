using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QueueManager.Application.FluentValidation;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.role;
using QueueManager.Application.JwtTokenHandler.Handlers;
using QueueManager.Application.Services;
using QueueManager.Application.Services.role_services;
using QueueManager.Domain.Models.BusinessModels;

namespace QueueManager.Application.ServiceConfiguration
{
    public static class StartUp
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<CategoryService>();
            services.AddTransient<ClinicService>();
            services.AddTransient<DoctorRatingService>();
            services.AddTransient<DoctorService>();
            services.AddTransient<HistoryService>();
            services.AddTransient<PatientService>();
            services.AddTransient<WaitlistService>();
            
            services.AddScoped<UserService>();
            services.AddScoped<RoleService>();
            services.AddScoped<PermissionService>();
            services.AddScoped<TokenHandler>();
            
            services.AddTransient<IValidator<Clinic>,ClinicValidator>();

            return services;
        }
    }
}
