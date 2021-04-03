using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class MarcasRepository : EFRepositoryBase<Marcas, DefaultDbContext>, IMarcasRepository
    {
         public MarcasRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}