using Versatil.Domain.Interfaces.Repositories.Base;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Repositories
{
    public interface IGenericRepositoryDefaultDbContext<TEntity> :
        IRepositoryBaseReader<TEntity>,
        IRepositoryBaseWriter<TEntity>,
        IRepositoryBaseProcedure where TEntity : Entity
    {

    }
}
