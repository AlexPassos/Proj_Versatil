using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class SituacaoTributariaRepository : EFRepositoryBase<SituacaoTributaria, DefaultDbContext>, ISituacaoTributariaRepository
    {
         public SituacaoTributariaRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}