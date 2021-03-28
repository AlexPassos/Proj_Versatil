using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IBancosService
    {
        Task<BancosViewModel> GetBancoId(int id);
        Task<IEnumerable<BancosViewModel>> GetBancosAll();

        Task Salvar(BancosViewModel bancoModel);

        Task Update(BancosViewModel bancoModel);

        Task Delete(int id);
    }
}