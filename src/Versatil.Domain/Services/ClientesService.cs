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
    public class ClientesService : BaseService, IClientesService
    {
        private readonly IMapper _mapper;
        private readonly IClientesRepository _clientesRepository;
        private readonly IProfissoesRepository _profissoesRepository;
        public ClientesService(INotificador notificador,
                                   IUser user,
                                   IMapper mapper,
                                   IClientesRepository clientesRepository,
                                   IProfissoesRepository profissoesRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _clientesRepository = clientesRepository;
            _profissoesRepository = profissoesRepository;
        }

        public async Task<IEnumerable<ClientesViewModel>> GetClientesAll()
        {
            var dados = await _clientesRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.nome));
            return _mapper.Map<IEnumerable<ClientesViewModel>>(dados);
        }

        public async Task<ClientesViewModel> GetClientesId(int id)
        {
            var dados = await _clientesRepository.Get(x => x.id == id);
            return _mapper.Map<ClientesViewModel>(dados);
        }

        public async Task Salvar(ClientesViewModel model)
        {
            var dados = _mapper.Map<Clientes>(model);
            await _clientesRepository.Add(dados);
        }

        public async Task Update(ClientesViewModel model)
        {
            var dados = _mapper.Map<Clientes>(model);
            await _clientesRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _clientesRepository.Delete(id);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<ClientesViewModel> GetClientesCpf(string cpfcnpj)
        {
            var dados = await _clientesRepository.Get(x => x.cpfcnpj == cpfcnpj);
            return _mapper.Map<ClientesViewModel>(dados);
        }

        public async Task<IEnumerable<ProfissoesViewModel>> GetProfissoes()
        {
            var dados = await _profissoesRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.descricao));
            return _mapper.Map<IEnumerable<ProfissoesViewModel>>(dados);
        }
    }
}