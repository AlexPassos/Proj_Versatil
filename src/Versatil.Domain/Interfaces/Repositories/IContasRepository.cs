using System.Collections.Generic;
using Versatil.Domain.Entities;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Repositories
{
    public interface IContasRepository : IRepositoryBase<Contas>
    {
        IEnumerable<ContasViewModel> GetContasAll(int idgrupo, int idsubgupo);
        int GetMaxID(int idgrupo, int idsubgrupo);
    }
}