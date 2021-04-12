using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IContasSubgruposService
    {
        Task<ContasSubgruposViewModel> GetSubgrupoId(int id);
        IEnumerable<ContasSubgruposViewModel> GetSubgruposAll(int id);
        Task<IEnumerable<ContasSubgruposViewModel>> GetSubgrupos(int id);

        int GetMaxCodigo(int idgrupo);
        Task Salvar(ContasSubgruposViewModel model);

        Task Update(ContasSubgruposViewModel model);

        Task Delete(int id);

    }
}