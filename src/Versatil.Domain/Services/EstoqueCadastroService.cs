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
    public class EstoqueCadastroService : BaseService, IEstoqueCadastroService
    {
        private readonly IMapper _mapper;
        private readonly IEstoqueCadastroRepository _cadastroRepository;
        private readonly IUnidadesRepository _unidadesRepository;
        private readonly IMarcasRepository _marcasRepository;
        private readonly ICfopRepository _cfopRepository;
        private readonly ISituacaoTributariaRepository _icmsRepository;
        private readonly ISituacaoTributariaPisRepository _pisRepository;
        private readonly ISituacaoTributariaCofinsRepository _cofinsRepository;
        private readonly ISituacaoTributariaIpiRepository _ipiRepository;

        public EstoqueCadastroService(INotificador notificador,
                                      IUser user,
                                      IMapper mapper,
                                      IEstoqueCadastroRepository cadastroRepository,
                                      IUnidadesRepository unidadesRepository,
                                      IMarcasRepository marcasRepository,
                                      ICfopRepository cfopRepository,
                                      ISituacaoTributariaRepository icmsRepository,
                                      ISituacaoTributariaPisRepository pisRepository,
                                      ISituacaoTributariaCofinsRepository cofinsRepository,
                                      ISituacaoTributariaIpiRepository ipiRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _cadastroRepository = cadastroRepository;
            _unidadesRepository = unidadesRepository;
            _marcasRepository = marcasRepository;
            _cfopRepository = cfopRepository;
            _icmsRepository = icmsRepository;
            _pisRepository = pisRepository;
            _cofinsRepository = cofinsRepository;
            _ipiRepository = ipiRepository;
        }

        public async Task<IEnumerable<EstoqueCadastroViewModel>> GetEstoqueCadastroAll()
        {
            var dados = await _cadastroRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.descricao));
            return _mapper.Map<IEnumerable<EstoqueCadastroViewModel>>(dados);
        }

        public async Task<EstoqueCadastroViewModel> GetEstoqueCadastroId(int id)
        {
            var dados = await _cadastroRepository.Get(x => x.id == id);
            return _mapper.Map<EstoqueCadastroViewModel>(dados);
        }

        public async Task Salvar(EstoqueCadastroViewModel model)
        {
            var dados = _mapper.Map<EstoqueCadastro>(model);
            await _cadastroRepository.Add(dados);
        }

        public async Task Update(EstoqueCadastroViewModel model)
        {
            var dados = _mapper.Map<EstoqueCadastro>(model);
            await _cadastroRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _cadastroRepository.Delete(id);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable<UnidadesViewModel>> GetUnidades()
        {
            var dados = await _unidadesRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.descricao));
            return _mapper.Map<IEnumerable<UnidadesViewModel>>(dados);
        }
        public async Task<IEnumerable<MarcasViewModel>> GetMarcas()
        {
            var dados = await _marcasRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.descricao));
            return _mapper.Map<IEnumerable<MarcasViewModel>>(dados);
        }
        public async Task<IEnumerable<CfopViewModel>> GetCFOP()
        {
            var dados = await _cfopRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.cfop));
            return _mapper.Map<IEnumerable<CfopViewModel>>(dados);
        }

        public async Task<IEnumerable<SituacaoTributariaViewModel>> GetICMS()
        {
            var dados = await _icmsRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.id));
            return _mapper.Map<IEnumerable<SituacaoTributariaViewModel>>(dados);
        }

        public async Task<IEnumerable<SituacaoTributariaPisViewModel>> GetPIS()
        {
            var dados = await _pisRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.id));
            return _mapper.Map<IEnumerable<SituacaoTributariaPisViewModel>>(dados);
        }

        public async Task<IEnumerable<SituacaoTributariaCofinsViewModel>> GetCOFINS()
        {
            var dados = await _cofinsRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.id));
            return _mapper.Map<IEnumerable<SituacaoTributariaCofinsViewModel>>(dados);
        }

        public async Task<IEnumerable<SituacaoTributariaIpiViewModel>> GetIPI()
        {
            var dados = await _ipiRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.id));
            return _mapper.Map<IEnumerable<SituacaoTributariaIpiViewModel>>(dados);
        }
    }
}