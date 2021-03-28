using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetMany(Expression<Func<TEntity, bool>> expressionSearch, Expression<Func<TEntity, object>>[] expressionIncludes = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> expressionSearch, Expression<Func<TEntity, object>>[] expressionIncludes = null);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);
        
    }
}