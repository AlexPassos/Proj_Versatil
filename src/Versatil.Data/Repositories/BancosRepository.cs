using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class BancosRepository : EFRepositoryBase<Bancos, DefaultDbContext>, IBancosRepository
    {
         public BancosRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}