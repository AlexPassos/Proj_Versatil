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
    public class ContasRepository : EFRepositoryBase<Contas, DefaultDbContext>, IContasRepository
    {
        private readonly IMapper _mapper;
        private readonly DefaultDbContext context;
         public ContasRepository(DefaultDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
            context = dbContext;
        }
        public IEnumerable<ContasViewModel> GetContasAll(int idgrupo, int idsubgupo)
        {
            var dados = context.CONTASs.Where(x => 
                        x.contasdemonstrativosID == 1 &&
                        x.contasgruposID == idgrupo && 
                        x.contassubgruposID == idsubgupo).OrderBy(o => o.codigo).ToList();
            return _mapper.Map<IEnumerable<ContasViewModel>>(dados);
        }

        public int GetMaxID(int idgrupo, int idsubgrupo)
        {
            var dados = 0;
            try
            {
                dados = context.CONTASs.Where(q => q.contasdemonstrativosID == 1 && q.contasgruposID == idgrupo && q.contassubgruposID == idsubgrupo)
                    .Max(m => m.codigo);
            }
            catch { }

            return dados;
        }
    }
}