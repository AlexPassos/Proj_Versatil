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
    public class ContasService : BaseService, IContasService
    {

        private readonly IMapper _mapper;
        private readonly IContasRepository _contasRepository;

        public ContasService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IContasRepository contasRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _contasRepository = contasRepository;
        }

        public async Task<ContasViewModel> GetContaId(int id)
        {
            var dados = await _contasRepository.Get(x => x.id == id);
            return _mapper.Map<ContasViewModel>(dados);
        }

        public IEnumerable<ContasViewModel> GetContasAll(int idgrupo, int idsubgrupo)
        {
            var dados = _contasRepository.GetContasAll(idgrupo, idsubgrupo);
            
            return dados;
        }

        public int GetMaxCodigo(int idgrupo, int idsubgrupo)
        {
            return _contasRepository.GetMaxID(idgrupo, idsubgrupo);
        }

        public async Task Salvar(ContasViewModel model)
        {
            var dados = _mapper.Map<Contas>(model);
            await _contasRepository.Add(dados);
        }

        public async Task Update(ContasViewModel model)
        {
            var dados = _mapper.Map<Contas>(model);
            await _contasRepository.Update(dados);
        }
        public async Task Delete(int id)
        {
            await _contasRepository.Delete(id);
        }
    }
}