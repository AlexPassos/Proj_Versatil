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
    public class EmpresasService : BaseService, IEmpresasService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresasRepository _empresasRepository;

        public EmpresasService(INotificador notificador,
                               IUser user,
                               IMapper mapper,
                               IEmpresasRepository empresasRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _empresasRepository = empresasRepository;
        }

        public async Task<IEnumerable<EmpresasViewModel>> GetEmpresasAll()
        {
            var dados = await _empresasRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.razao));
            return _mapper.Map<IEnumerable<EmpresasViewModel>>(dados);
        }

        public async Task<EmpresasViewModel> GetEmpresaId(int id)
        {
            var dados = await _empresasRepository.Get(x => x.id == id);
            return _mapper.Map<EmpresasViewModel>(dados);
        }

        public async Task Salvar(EmpresasViewModel model)
        {
            var dados = _mapper.Map<Empresas>(model);
            await _empresasRepository.Add(dados);
        }

        public async Task Update(EmpresasViewModel model)
        {
            var dados = _mapper.Map<Empresas>(model);
            await _empresasRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _empresasRepository.Delete(id);
            }
            catch (Exception ex)
            {

            }
        }
    }
}