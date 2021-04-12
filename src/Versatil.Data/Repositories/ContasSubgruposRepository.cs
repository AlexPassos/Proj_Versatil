using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versatil.Data.Data;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.ViewModels;

namespace Versatil.Data.Repositories
{
    public class ContasSubgruposRepository : EFRepositoryBase<ContasSubgrupos, DefaultDbContext>, IContasSubgruposRepository
    {
        private readonly IMapper _mapper;
        private readonly DefaultDbContext context;
         public ContasSubgruposRepository(DefaultDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
            context = dbContext;
        }

        public IEnumerable<ContasSubgruposViewModel> GetSubgruposAll(int id)
        {
            var dados = context.CONTASSUBGRUPOSs.Where(x => x.contasgruposID == id).OrderBy(o => o.codigo).ToList();
            return _mapper.Map<IEnumerable<ContasSubgruposViewModel>>(dados);
        }

        public int GetMaxID(int idgrupo)
        {
            var dados = 0;
            try
            {
                dados = context.CONTASSUBGRUPOSs.Where(q => q.contasdemonstrativosID == 1 && q.contasgruposID == idgrupo)
                    .Max(m => m.codigo);
            }
            catch { }

            return dados;
        }
    }
}