using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class CidadesRepository : EFRepositoryBase<Cidades, DefaultDbContext>, ICidadesRepository
    {
         public CidadesRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}