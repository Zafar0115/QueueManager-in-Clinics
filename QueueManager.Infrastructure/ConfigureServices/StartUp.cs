using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Application.JwtTokenHandler.Handlers;
using QueueManager.Infrastructure.DataAccess;
using QueueManager.Infrastructure.DataAccess.Interceptor;
using QueueManager.Infrastructure.Implementation;
using QueueManager.Infrastructure.Implementation.common;
using QueueManager.Infrastructure.Implementation.userrole;

namespace QueueManager.Infrastructure.DbConfiguration
{
    public static class StartUp
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddDbContext<IApplicationDbContext, ClinicDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IClinicRepository, ClinicRepository>();
            services.AddScoped<IDoctorRatingRepository, DoctorRatingRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IWaitlistRepository, WaitListRepository>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRefreshTokenService, UserRefreshTokenService>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
