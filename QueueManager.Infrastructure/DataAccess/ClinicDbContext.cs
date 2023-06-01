
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using QueueManager.Infrastructure.DataAccess.Interceptor;
using System.Reflection;

namespace QueueManager.Infrastructure.DataAccess
{
    public class ClinicDbContext : DbContext, IApplicationDbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _interceptor;
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options,AuditableEntitySaveChangesInterceptor interceptor)
            : base(options)
        {
            _interceptor = interceptor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().Navigation(r => r.Permissions).AutoInclude();
            modelBuilder.Entity<User>().Navigation(u=>u.Roles).AutoInclude();
            modelBuilder.Entity<UserRefreshToken>().Navigation(u => u.User).AutoInclude();
                
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_interceptor);
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorRating> DoctorRatings { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<WaitList> WaitLists { get; set; }
        public DbSet<User> Users{get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        ChangeTracker IApplicationDbContext.ChangeTracker { get => base.ChangeTracker; }
      
    }       
}
