using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;

namespace Versatil.Data.Repositories
{
    public class SituacaoTributariaCofinsRepository : EFRepositoryBase<SituacaoTributariaCofins, DefaultDbContext>, ISituacaoTributariaCofinsRepository
    {
         public SituacaoTributariaCofinsRepository(DefaultDbContext dbContext) : base(dbContext)
        {
        }
    }
}