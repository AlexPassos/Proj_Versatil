using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IContasDemonstrativosService
    {
        Task<ContasDemonstrativosViewModel> GetDemonstrativoId(int id);
        Task<IEnumerable<ContasDemonstrativosViewModel>> GetDemonstrativosAll();
      
    }
}