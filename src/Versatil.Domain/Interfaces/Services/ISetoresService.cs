using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface ISetoresService
    {
        Task<SetoresViewModel> GetSetorId(int id);
        Task<IEnumerable<SetoresViewModel>> GetSetoresAll();

        Task Salvar(SetoresViewModel vModel);

        Task Update(SetoresViewModel vModel);

        Task Delete(int id);
    }
}