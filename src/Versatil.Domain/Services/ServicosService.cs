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
    public class ServicosService : BaseService, IServicosService
    {

        private readonly IMapper _mapper;
        private readonly IServicosRepository _servicosRepository;

        public ServicosService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IServicosRepository servicosRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _servicosRepository = servicosRepository;
        }

        public async Task<IEnumerable<ServicosViewModel>> GetServicosAll()
        {
            var dados = await _servicosRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.descricao));
            return _mapper.Map<IEnumerable<ServicosViewModel>>(dados);
        }

        public async Task<ServicosViewModel> GetServicoId(int id)
        {
            var dados = await _servicosRepository.Get(x => x.id == id);
            return _mapper.Map<ServicosViewModel>(dados);
        }

        public async Task Salvar(ServicosViewModel vModel)
        {
            var dados =  _mapper.Map<Servicos>(vModel);
            await _servicosRepository.Add(dados);
        }

        public async Task Update(ServicosViewModel vModel)
        {
            var dados = _mapper.Map<Servicos>(vModel);
            await _servicosRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try{
                await _servicosRepository.Delete(id);
            } catch (Exception ex){

            }
        }
    }
}