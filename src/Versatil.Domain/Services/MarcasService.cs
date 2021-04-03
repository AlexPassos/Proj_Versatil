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
    public class MarcasService : BaseService, IMarcasService
    {

        private readonly IMapper _mapper;
        private readonly IMarcasRepository _marcasRepository;

        public MarcasService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IMarcasRepository marcasRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _marcasRepository = marcasRepository;
        }

        public async Task<IEnumerable<MarcasViewModel>> GetMarcasAll()
        {
            var dados = await _marcasRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.descricao));
            return _mapper.Map<IEnumerable<MarcasViewModel>>(dados);
        }

        public async Task<MarcasViewModel> GetMarcaId(int id)
        {
            var dados = await _marcasRepository.Get(x => x.id == id);
            return _mapper.Map<MarcasViewModel>(dados);
        }

        public async Task Salvar(MarcasViewModel marcaModel)
        {
            var dados =  _mapper.Map<Marcas>(marcaModel);
            await _marcasRepository.Add(dados);
        }

        public async Task Update(MarcasViewModel marcaModel)
        {
            var dados = _mapper.Map<Marcas>(marcaModel);
            await _marcasRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try{
                await _marcasRepository.Delete(id);
            } catch (Exception ex){

            }
        }
    }
}