using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.Entities;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Repositories
{
    public interface IContasSubgruposRepository : IRepositoryBase<ContasSubgrupos>
    {
        IEnumerable<ContasSubgruposViewModel> GetSubgruposAll(int id);
        int GetMaxID(int idgrupo);
    }
}