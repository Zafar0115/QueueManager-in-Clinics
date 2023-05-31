using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using QueueManager.Domain.Models.BusinessModels;
using QueueManager.Domain.Models.UserModels;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace QueueManager.Application.Interfaces.Common
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; }
        DbSet<Clinic> Clinics { get; }
        DbSet<Doctor> Doctors { get; }
        DbSet<DoctorRating> DoctorRatings { get; }
        DbSet<History> Histories { get; }
        DbSet<Patient> Patients { get; }
        DbSet<WaitList> WaitLists { get; }

        DbSet<User> Users { get; }
        DbSet<Permission> Permissions { get; }
        DbSet<Role> Roles { get; }
        DbSet<UserRefreshToken> UserRefreshTokens { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        DbSet<T> Set<T>() where T : class;
        ChangeTracker ChangeTracker { get; }
        void Dispose();
        EntityEntry Entry(object entity);
        DatabaseFacade Database { get;}
    }
}
