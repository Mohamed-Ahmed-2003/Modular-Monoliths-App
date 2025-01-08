using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Shared.Data.Interceptors;

public class AuditableEntityInterceptor :SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        AuditEntities(eventData.Context);
        return base.SavingChanges(eventData, result);
    }


    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        AuditEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private static void AuditEntities(DbContext? ctx)
    {
        if (ctx is null||!ctx.ChangeTracker.HasChanges()) return;
        var entities = ctx.ChangeTracker.Entries<IEntity>();
        foreach (var entityEntry in entities)
        {
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Entity.CreatedBy = entityEntry.Metadata.Name;
                    entityEntry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Entity.ModifiedBy = entityEntry.Metadata.Name;
                    entityEntry.Entity.ModifiedOn = DateTime.UtcNow;
                    break;
            }
        }
    }
}