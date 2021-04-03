using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IFuncionariosService
    {
        Task<FuncionariosViewModel> GetFuncionariosId(int id);
        Task<FuncionariosViewModel> GetFuncionariosCpf(string cpf);
        Task<IEnumerable<FuncionariosViewModel>> GetFuncionariosAll();

        Task Salvar(FuncionariosViewModel model);

        Task Update(FuncionariosViewModel model);

        Task Delete(int id);
    }
}