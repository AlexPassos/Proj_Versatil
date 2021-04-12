using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class UnidadesRepository : EFRepositoryBase<Unidades, DefaultDbContext>, IUnidadesRepository
    {
         public UnidadesRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}