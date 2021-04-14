using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class EstoqueCadastroRepository : EFRepositoryBase<EstoqueCadastro, DefaultDbContext>, IEstoqueCadastroRepository
    {
         public EstoqueCadastroRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}