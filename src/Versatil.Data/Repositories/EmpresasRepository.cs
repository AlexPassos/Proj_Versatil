using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class EmpresasRepository : EFRepositoryBase<Empresas, DefaultDbContext>, IEmpresasRepository
    {
         public EmpresasRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}