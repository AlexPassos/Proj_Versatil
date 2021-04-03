using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBaseWriter<TEntity> where TEntity : Entity
    {
        // Write
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(ICollection<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(ICollection<TEntity> entities);

        Task DeleteAsync(int id);
        Task DeleteAsync(Guid id);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(ICollection<TEntity> entities);
    }
}
