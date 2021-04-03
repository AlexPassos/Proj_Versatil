using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IMarcasService
    {
        Task<MarcasViewModel> GetMarcaId(int id);
        Task<IEnumerable<MarcasViewModel>> GetMarcasAll();

        Task Salvar(MarcasViewModel marcaModel);

        Task Update(MarcasViewModel marcaModel);

        Task Delete(int id);
    }
}