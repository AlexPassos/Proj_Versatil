using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IContasService
    {
        Task<ContasViewModel> GetContaId(int id);
        IEnumerable<ContasViewModel> GetContasAll(int idgrupo, int idsubgupo);
        int GetMaxCodigo(int idgrupo, int idsubgrupo);
        Task Salvar(ContasViewModel model);

        Task Update(ContasViewModel model);

        Task Delete(int id);

    }
}