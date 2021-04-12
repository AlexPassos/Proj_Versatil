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
    public class ContasGruposService : BaseService, IContasGruposService
    {

        private readonly IMapper _mapper;
        private readonly IContasGruposRepository _gruposRepository;

        public ContasGruposService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IContasGruposRepository grupoRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _gruposRepository = grupoRepository;
        }

        public async Task<ContasGruposViewModel> GetGrupoId(int id)
        {
            var dados = await _gruposRepository.Get(x => x.id == id);
            return _mapper.Map<ContasGruposViewModel>(dados);
        }

        public IEnumerable<ContasGruposViewModel> GetGruposAll(int id)
        {
            var dados = _gruposRepository.GetGruposAll(id);
            
            return dados;
        }

        public async Task<IEnumerable<ContasGruposViewModel>> GetGrupos(int id)
        {
            var dados = await _gruposRepository.GetMany(g => g.contasdemonstrativosID == id, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.codigo));
            return _mapper.Map<IEnumerable<ContasGruposViewModel>>(dados);
        }

        public async Task Salvar(ContasGruposViewModel model)
        {
            var dados = _mapper.Map<ContasGrupos>(model);
            await _gruposRepository.Add(dados);
        }

        public async Task Update(ContasGruposViewModel model)
        {
            var dados = _mapper.Map<ContasGrupos>(model);
            await _gruposRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            //try{
            await _gruposRepository.Delete(id);
            //} catch (Exception ex){

            //}
        }

        public int GetMaxCodigo()
        {
            return _gruposRepository.GetMaxID();
        }

        
    }
}