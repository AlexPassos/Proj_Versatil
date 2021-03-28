using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IEmpresasService
    {
        Task<EmpresasViewModel> GetEmpresaId(int id);
        Task<IEnumerable<EmpresasViewModel>> GetEmpresasAll();

        Task Salvar(EmpresasViewModel model);

        Task Update(EmpresasViewModel model);

        Task Delete(int id);
    }
}