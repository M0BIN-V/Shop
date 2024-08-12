using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Domain.Entities.Abstractions;

namespace Persistence.Interceptors;

internal class AddEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        Apply(eventData);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        Apply(eventData);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    static void Apply(DbContextEventData eventData)
    {
        if (eventData.Context is not null)
        {
            var addedEntities = eventData.Context.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in addedEntities)
            {
                if (entry.Entity is ICodedEntity codedEntity)
                {
                    codedEntity.Code = Guid.NewGuid();
                }
            }
        }
    }
}
