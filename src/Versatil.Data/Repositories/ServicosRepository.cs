using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class ServicosRepository : EFRepositoryBase<Servicos, DefaultDbContext>, IServicosRepository
    {
         public ServicosRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}