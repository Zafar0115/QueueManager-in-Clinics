﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using QueueManager.Application.Interfaces.Administration;
using QueueManager.Domain.Abstract;

namespace QueueManager.Infrastructure.DataAccess.Interceptor
{
    public class AuditableEntitySaveChangesInterceptor:SaveChangesInterceptor
    {
        private readonly ICurrentUserService _currentUserService;

        public AuditableEntitySaveChangesInterceptor(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void UpdateEntities(DbContext? context)
        {
           if (context == null) return;
            foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created=DateTime.UtcNow;
                }

                if(entry.State == EntityState.Modified|| entry.State == EntityState.Added)
                {
                        entry.Entity.LastModifiedBy= _currentUserService.UserId;
                    entry.Entity.LastModified=DateTime.UtcNow;
                }
            }
        }

    }  
}
