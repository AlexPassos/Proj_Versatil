using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IContasGruposService
    {
        Task<ContasGruposViewModel> GetGrupoId(int id);
        IEnumerable<ContasGruposViewModel> GetGruposAll(int id);
        Task<IEnumerable<ContasGruposViewModel>> GetGrupos(int id);
        int GetMaxCodigo();
        Task Salvar(ContasGruposViewModel model);

        Task Update(ContasGruposViewModel model);

        Task Delete(int id);

    }
}