using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Query
{
    public class BaseQuery<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public BaseQuery(DbContext dbContext)
        {
            _context = dbContext;
        }

        protected DbSet<TEntity> Query => _context.Set<TEntity>();

        public virtual async Task<TEntity> FindAsync(object id)
        {
            return await Query.FindAsync(id);
        }
        public static IQueryable<TEntity> Include<TEntity>(IEnumerable<string> navigationPropertyPaths, IQueryable<TEntity> source)
            where TEntity : class
        {
            return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
        }
        protected virtual IQueryable<TEntity> IncludeAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = _context.Set<TEntity>()
                .Include(_context.GetIncludePaths(typeof(TEntity)));
            if (predicate != null)
                query = query.Where(predicate);
            return query;
        }

    }
}
public static class IncludeExtensions
{

    public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> source, IEnumerable<string> navigationPropertyPaths)
        where TEntity : class
    {
        return navigationPropertyPaths.Aggregate(source, (query, path) => query.Include(path));
    }

    public static IEnumerable<string> GetIncludePaths(this DbContext context, Type clrEntityType)
    {
        var entityType = context.Model.FindEntityType(clrEntityType);
        var includedNavigations = new HashSet<INavigation>();
        var stack = new Stack<IEnumerator<INavigation>>();
        while (true)
        {
            var entityNavigations = new List<INavigation>();
            foreach (var navigation in entityType.GetNavigations())
            {
                if (includedNavigations.Add(navigation))
                    entityNavigations.Add(navigation);
            }
            if (entityNavigations.Count == 0)
            {
                if (stack.Count > 0)
                    yield return string.Join(".", stack.Reverse().Select(e => e.Current.Name));
            }
            else
            {
                foreach (var navigation in entityNavigations)
                {
                    var inverseNavigation = navigation.FindInverse();
                    if (inverseNavigation != null)
                        includedNavigations.Add(inverseNavigation);
                }
                stack.Push(entityNavigations.GetEnumerator());
            }
            while (stack.Count > 0 && !stack.Peek().MoveNext())
                stack.Pop();
            if (stack.Count == 0) break;
            entityType = stack.Peek().Current.GetTargetType();
        }
    }
}