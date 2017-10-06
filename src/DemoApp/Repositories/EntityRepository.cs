using DemoApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DemoApp.Repositories
{
    public abstract class EntityRepository<TEntity, TId>
        where TEntity : Entity<TId>, IAggregateRoot
        where TId : struct
    {
        protected EntityRepository(Context context)
        {
            Context = context;
        }

        protected Context Context { get; }
        protected virtual IQueryable<TEntity> Query => Context.Set<TEntity>().AsNoTracking().AsQueryable();

        protected static Expression<Func<TEntity, bool>> EqualsPredicate(TId id)
        {
            Expression<Func<TEntity, TId>> selector = x => x.Id;
            Expression<Func<TId>> closure = () => id;

            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(selector.Body, closure.Body),
                selector.Parameters);
        }

        protected async Task<T> GetAsync<T>(TId id, Func<TEntity, T> mapper)
        {
            var model = await Query.FirstOrDefaultAsync(EqualsPredicate(id));
            return model == null ? default(T) : mapper(model);
        }

        protected async Task<T[]> GetAsync<T>(TId[] ids, Func<TEntity, T> mapper)
        {
            var models = await Query.Where(x => ids.Contains(x.Id)).ToArrayAsync();
            return models?.Select(mapper).ToArray();
        }

        protected async Task<T[]> GetAsync<T>(Expression<Func<TEntity, bool>> predicate, Func<TEntity, T> mapper)
        {
            var entities = await Query.Where(predicate).ToArrayAsync();

            if (entities == null || entities.Length == 0)
            {
                return default(T[]);
            }

            return entities.Select(mapper).ToArray();
        }
    }
}