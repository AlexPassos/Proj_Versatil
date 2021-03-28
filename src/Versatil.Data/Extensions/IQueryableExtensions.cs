using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Versatil.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> AddIncludes<TEntity, TProperty>(this IQueryable<TEntity> source, Expression<Func<TEntity, TProperty>>[] expressionIncludes) where TEntity : class
        {
            if (expressionIncludes != null)
            {
                foreach (var include in expressionIncludes)
                {
                    if (include.Body is MemberExpression memberExpression)
                    {
                        source = source.Include(memberExpression.Member.Name);
                    }
                }
            }
            return source;
        }
    }
}