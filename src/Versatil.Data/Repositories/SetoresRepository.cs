using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class SetoresRepository : EFRepositoryBase<Setores, DefaultDbContext>, ISetoresRepository
    {
         public SetoresRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}