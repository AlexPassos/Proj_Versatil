using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IServicosService
    {
        Task<ServicosViewModel> GetServicoId(int id);
        Task<IEnumerable<ServicosViewModel>> GetServicosAll();

        Task Salvar(ServicosViewModel vModel);

        Task Update(ServicosViewModel vModel);

        Task Delete(int id);
    }
}