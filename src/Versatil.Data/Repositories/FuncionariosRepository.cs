using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class FuncionariosRepository : EFRepositoryBase<Funcionarios, DefaultDbContext>, IFuncionariosRepository
    {
         public FuncionariosRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}