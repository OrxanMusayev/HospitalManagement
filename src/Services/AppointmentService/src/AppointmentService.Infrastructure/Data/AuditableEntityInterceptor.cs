using AppointmentService.Application.Interfaces;
using AppointmentService.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AppointmentService.Infrastructure.Data;

public class AuditableEntityInterceptor(IUser user): SaveChangesInterceptor
{
    IUser _currentUser;
    private string? currentUserId = user.Id;
    
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        SetAuditedProperties(eventData.Context!);
        return base.SavingChanges(eventData, result);
    }
    
    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        SetAuditedProperties(eventData.Context!);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }
    
    private void SetAuditedProperties(DbContext context)
    {
        if (context == null) return;

        foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entry.State == EntityState.Added )
            {
                entry.Entity.CreatedDate = DateTime.UtcNow;
                entry.Entity.CreatedBy = currentUserId;
            }
            if (entry.State == EntityState.Modified)
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;
                entry.Entity.LastModifiedBy = currentUserId;
            }
        }
    }
}