using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueManager.Application.Abstraction;
using QueueManager.Application.Interfaces.common;
using QueueManager.Application.Interfaces.role;
using QueueManager.Infrastructure.DataAccess;
using QueueManager.Infrastructure.Implementation;
using QueueManager.Infrastructure.Implementation.common;
using QueueManager.Infrastructure.Implementation.userrole;

namespace QueueManager.Infrastructure.DbConfiguration
{
    public static class StartUp
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ClinicDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClinicRepository, ClinicRepository>();
            services.AddTransient<IDoctorRatingRepository, DoctorRatingRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IHistoryRepository, HistoryRepository>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IWaitlistRepository, WaitListRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            return services;
        }
    }
}
