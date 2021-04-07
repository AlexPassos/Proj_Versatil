using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class ProfissoesRepository : EFRepositoryBase<Profissoes, DefaultDbContext>, IProfissoesRepository
    {
         public ProfissoesRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}