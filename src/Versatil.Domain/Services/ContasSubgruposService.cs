using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Services
{
    public class ContasSubgruposService : BaseService, IContasSubgruposService
    {

        private readonly IMapper _mapper;
        private readonly IContasSubgruposRepository _subgruposRepository;

        public ContasSubgruposService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IContasSubgruposRepository subgrupoRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _subgruposRepository = subgrupoRepository;
        }

        public async Task<ContasSubgruposViewModel> GetSubgrupoId(int id)
        {
            var dados = await _subgruposRepository.Get(x => x.id == id);
            return _mapper.Map<ContasSubgruposViewModel>(dados);
        }

        public IEnumerable<ContasSubgruposViewModel> GetSubgruposAll(int id)
        {
            var dados = _subgruposRepository.GetSubgruposAll(id);
            return dados;
        }

        public async Task Salvar(ContasSubgruposViewModel model)
        {
            var dados = _mapper.Map<ContasSubgrupos>(model);
            await _subgruposRepository.Add(dados);
        }

        public async Task Update(ContasSubgruposViewModel model)
        {
            var dados = _mapper.Map<ContasSubgrupos>(model);
            await _subgruposRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            await _subgruposRepository.Delete(id);
        }

        public int GetMaxCodigo(int idgrupo)
        {
            return _subgruposRepository.GetMaxID(idgrupo);
        }

        public async Task<IEnumerable<ContasSubgruposViewModel>> GetSubgrupos(int id)
        {
            var dados = await _subgruposRepository.GetMany(x => x.contasgruposID == id, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.nome));
            return _mapper.Map<IEnumerable<ContasSubgruposViewModel>>(dados);
        }
    }
}