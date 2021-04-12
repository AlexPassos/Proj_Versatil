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
    public class BancosService : BaseService,IBancosService
    {

        private readonly IMapper _mapper;
        private readonly IBancosRepository _bancosRepository;

        public BancosService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IBancosRepository bancosRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _bancosRepository = bancosRepository;
        }

        public async Task<IEnumerable<BancosViewModel>> GetBancosAll()
        {
            var dados = await _bancosRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.descricao));
            return _mapper.Map<IEnumerable<BancosViewModel>>(dados);
        }

        public async Task<BancosViewModel> GetBancoId(int id)
        {
            var dados = await _bancosRepository.Get(x => x.id == id);
            return _mapper.Map<BancosViewModel>(dados);
        }

        public async Task Salvar(BancosViewModel bancoModel)
        {
            var dados =  _mapper.Map<Bancos>(bancoModel);
            await _bancosRepository.Add(dados);
        }

        public async Task Update(BancosViewModel bancoModel)
        {
            var dados = _mapper.Map<Bancos>(bancoModel);
            await _bancosRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            //try{
                await _bancosRepository.Delete(id);
            //} catch (Exception ex){

            //}
        }
    }
}