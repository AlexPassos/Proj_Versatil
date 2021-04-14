using System.Collections.Generic;
using System.Threading.Tasks;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Services
{
    public interface IEstoqueCadastroService
    {
        Task<EstoqueCadastroViewModel> GetEstoqueCadastroId(int id);        
        Task<IEnumerable<EstoqueCadastroViewModel>> GetEstoqueCadastroAll();
        Task<IEnumerable<UnidadesViewModel>> GetUnidades();
        Task<IEnumerable<MarcasViewModel>> GetMarcas();
        Task<IEnumerable<CfopViewModel>> GetCFOP();
        Task<IEnumerable<SituacaoTributariaViewModel>> GetICMS();
        Task<IEnumerable<SituacaoTributariaPisViewModel>> GetPIS();
        Task<IEnumerable<SituacaoTributariaCofinsViewModel>> GetCOFINS();
        Task<IEnumerable<SituacaoTributariaIpiViewModel>> GetIPI();

        Task Salvar(EstoqueCadastroViewModel model);

        Task Update(EstoqueCadastroViewModel model);

        Task Delete(int id);
    }
}