using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class ContasDemonstrativosRepository : EFRepositoryBase<ContasDemonstrativos, DefaultDbContext>, IContasDemonstrativosRepository
    {
         public ContasDemonstrativosRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}