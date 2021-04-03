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
    public class SetoresService : BaseService, ISetoresService
    {

        private readonly IMapper _mapper;
        private readonly ISetoresRepository _setoresRepository;

        public SetoresService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             ISetoresRepository setoresRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _setoresRepository = setoresRepository;
        }

        public async Task<IEnumerable<SetoresViewModel>> GetSetoresAll()
        {
            var dados = await _setoresRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.descricao));
            return _mapper.Map<IEnumerable<SetoresViewModel>>(dados);
        }

        public async Task<SetoresViewModel> GetSetorId(int id)
        {
            var dados = await _setoresRepository.Get(x => x.id == id);
            return _mapper.Map<SetoresViewModel>(dados);
        }

        public async Task Salvar(SetoresViewModel vModel)
        {
            var dados =  _mapper.Map<Setores>(vModel);
            await _setoresRepository.Add(dados);
        }

        public async Task Update(SetoresViewModel vModel)
        {
            var dados = _mapper.Map<Setores>(vModel);
            await _setoresRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try{
                await _setoresRepository.Delete(id);
            } catch (Exception ex){

            }
        }
    }
}