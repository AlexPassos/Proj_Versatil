using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Versatil.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBaseProcedure
    {
        Task ExecuteProcedureAsync(string procedureName, DbParameter[] parameters = null);
        Task<PEntity> GetByProcedureAsync<PEntity>(string procedureName, DbParameter[] parameters = null) where PEntity : class;
        Task<IEnumerable<PEntity>> GetManyByProcedureAsync<PEntity>(string procedureName, DbParameter[] parameters = null) where PEntity : class;
    }
}
