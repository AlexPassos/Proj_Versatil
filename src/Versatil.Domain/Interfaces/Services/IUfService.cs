using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.Entities;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IUfService
    {
        Task<Uf> GetUfId(int id);
        Task<IEnumerable<Uf>> GetUfAll();
    }
}