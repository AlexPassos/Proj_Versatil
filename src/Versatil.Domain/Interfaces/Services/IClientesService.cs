using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IClientesService
    {
        Task<ClientesViewModel> GetClientesId(int id);
        Task<ClientesViewModel> GetClientesCpf(string cpf);
        Task<IEnumerable<ClientesViewModel>> GetClientesAll();
        Task<IEnumerable<ProfissoesViewModel>> GetProfissoes();

        Task Salvar(ClientesViewModel model);

        Task Update(ClientesViewModel model);

        Task Delete(int id);
    }
}