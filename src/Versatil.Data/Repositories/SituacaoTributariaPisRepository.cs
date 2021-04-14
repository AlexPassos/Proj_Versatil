using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class SituacaoTributariaPisRepository : EFRepositoryBase<SituacaoTributariaPis, DefaultDbContext>, ISituacaoTributariaPisRepository
    {
         public SituacaoTributariaPisRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}