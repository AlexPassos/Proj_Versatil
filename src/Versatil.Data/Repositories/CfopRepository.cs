using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class CfopRepository : EFRepositoryBase<Cfop, DefaultDbContext>, ICfopRepository
    {
         public CfopRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}