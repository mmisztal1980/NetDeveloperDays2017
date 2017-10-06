using DemoApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Repositories
{
    /// <summary>
    /// Base Generic Repository implementing Insert & Update
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public abstract class Repository<TEntity, TId> : EntityRepository<TEntity, TId>
        where TEntity : Entity<TId>, IAggregateRoot
        where TId : struct
    {
        protected Repository(Context context)
            : base(context)
        {
        }

        protected virtual async Task<TId[]> InsertAsync(TEntity[] models, Action<TEntity, EntityEntry> updateAction = null)
        {
            Context.AddRange(models);
            await OnInsertAsync(updateAction);
            return models.Select(m => m.Id).ToArray();
        }

        protected virtual async Task<TId> InsertAsync(TEntity model, Action<TEntity, EntityEntry> updateAction = null)
        {
            var added = Context.Add(model);
            await OnInsertAsync(updateAction);
            return added.Entity.Id;
        }

        protected TId Update(TEntity model, Action<TEntity, EntityEntry> updateAction)
        {
            var updated = Context.Update(model);
            var allModified = Context.ChangeTracker.Entries().Where(r => r.State == EntityState.Modified).ToList();

            if (updateAction != null)
            {
                UpdateProperties(allModified, updateAction);
            }

            UpdateProperties(allModified, (x, entity) =>
            {
                x.ModifiedAt = DateTime.UtcNow;

                entity.Property("CreatedAt").IsModified = false;
            });

            Context.SaveChanges();

            return updated.Entity.Id;
        }

        private async Task OnInsertAsync(Action<TEntity, EntityEntry> updateAction = null)
        {
            var allAdded = Context.ChangeTracker.Entries().Where(r => r.State == EntityState.Added).ToList();

            UpdateProperties(allAdded,
                (x, entity) =>
                {
                    x.CreatedAt = DateTime.UtcNow;
                    x.ModifiedAt = DateTime.UtcNow;
                });

            UpdateProperties(allAdded, updateAction);

            await Context.SaveChangesAsync();
        }

        private static void UpdateProperties(IList<EntityEntry> entities, Action<TEntity, EntityEntry> action = null)
        {
            foreach (var entity in entities)
            {
                if (entity.Entity is TEntity item)
                {
                    action?.Invoke(item, entity);
                }
            }
        }
    }
}