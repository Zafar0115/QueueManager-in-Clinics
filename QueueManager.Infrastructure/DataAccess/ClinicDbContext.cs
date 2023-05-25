using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QueueManager.Application.Interfaces.Common;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using System.Reflection;

namespace QueueManager.Infrastructure.DataAccess
{
    public class ClinicDbContext : DbContext, IApplicationDbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          
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
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken);
            //await Database.ExecuteSqlRawAsync("update user_refresh_token set is_active=false where expiry_date<(select current_timestamp)");
            return result;
        }
    }       
}
