using System.Collections.Generic;
using Versatil.Domain.Entities;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Interfaces.Repositories
{
    public interface IContasGruposRepository : IRepositoryBase<ContasGrupos>
    {
        IEnumerable<ContasGruposViewModel> GetGruposAll(int id);
        int GetMaxID();
    }
}