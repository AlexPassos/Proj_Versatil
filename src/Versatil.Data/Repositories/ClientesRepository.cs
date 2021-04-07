using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class ClientesRepository : EFRepositoryBase<Clientes, DefaultDbContext>, IClientesRepository
    {
         public ClientesRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}