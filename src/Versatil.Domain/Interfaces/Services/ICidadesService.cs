using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Services
{
    public interface ICidadesService
    {
        Task<Cidades> GetCidadeId(int id);
        Task<Cidades> GetCidadeIbge(string codibge);
        Task<IEnumerable<Cidades>> GetCidades(int id);
        Task<IEnumerable<Cidades>> GetCidadesAll();
    }
}