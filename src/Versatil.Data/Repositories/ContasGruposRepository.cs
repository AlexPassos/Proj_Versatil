using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.ViewModels;

namespace Versatil.Data.Repositories
{
    public class ContasGruposRepository : EFRepositoryBase<ContasGrupos, DefaultDbContext>, IContasGruposRepository
    {
        private readonly IMapper _mapper;
        private readonly DefaultDbContext context;
         public ContasGruposRepository(DefaultDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
            context = dbContext;
        }
        public IEnumerable<ContasGruposViewModel> GetGruposAll(int id)
        {
            var dados = context.CONTASGRUPOSs.Where(x => x.contasdemonstrativosID == id).OrderBy(o => o.codigo).ToList();
            return _mapper.Map<IEnumerable<ContasGruposViewModel>>(dados);
        }

        public int GetMaxID()
        {
            var dados = 0;
            try
            {
                dados = context.CONTASGRUPOSs.Where(q => q.contasdemonstrativosID == 1)
                    .Max(m => m.codigo);
            }
            catch { }            
            return dados;
        }
    }
}