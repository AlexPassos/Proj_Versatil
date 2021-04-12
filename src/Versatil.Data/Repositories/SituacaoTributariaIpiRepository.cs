using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class SituacaoTributariaIpiRepository : EFRepositoryBase<SituacaoTributariaIpi, DefaultDbContext>, ISituacaoTributariaIpiRepository
    {
         public SituacaoTributariaIpiRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}