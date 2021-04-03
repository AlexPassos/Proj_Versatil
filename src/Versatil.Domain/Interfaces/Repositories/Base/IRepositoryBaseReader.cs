using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBaseReader<TEntity> where TEntity : Entity
    {
        // Read
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> searchExpression);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> searchExpression, Expression<Func<TEntity, object>> orderByExpression = null);
        Task<PagedResultViewModel<TEntity>> GetPaged(Expression<Func<TEntity, bool>> searchExpression, Expression<Func<TEntity, object>> orderByExpression = null, int page = 1, int pageSize = 10);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> searchExpression);
    }
}
