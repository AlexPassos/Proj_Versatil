using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.Interfaces.Services;
using Versatil.Domain.ViewModels;

namespace Versatil.Domain.Services
{
    public class FuncionariosService : IFuncionariosService
    {
        private readonly IMapper _mapper;
        private readonly IFuncionariosRepository _funcionariosRepository;

        public FuncionariosService(IMapper mapper, IFuncionariosRepository funcionariosRepository)
        {
            _mapper = mapper;
            _funcionariosRepository = funcionariosRepository;
        }

        public async Task<IEnumerable<FuncionariosViewModel>> GetFuncionariosAll()
        {
            var dados = await _funcionariosRepository.GetMany(x => true, expressionIncludes: null, orderBy: y => y.OrderBy(o => o.nome));
            return _mapper.Map<IEnumerable<FuncionariosViewModel>>(dados);
        }

        public async Task<FuncionariosViewModel> GetFuncionariosId(int id)
        {
            var dados = await _funcionariosRepository.Get(x => x.id == id);
            return _mapper.Map<FuncionariosViewModel>(dados);
        }

        public async Task Salvar(FuncionariosViewModel model)
        {
            var dados = _mapper.Map<Funcionarios>(model);
            await _funcionariosRepository.Add(dados);
        }

        public async Task Update(FuncionariosViewModel model)
        {
            var dados = _mapper.Map<Funcionarios>(model);
            await _funcionariosRepository.Update(dados);
        }

        public async Task Delete(int id)
        {
            try
            {
                await _funcionariosRepository.Delete(id);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<FuncionariosViewModel> GetFuncionariosCpf(string cpf)
        {
            var dados = await _funcionariosRepository.Get(x => x.cpf == cpf);
            return _mapper.Map<FuncionariosViewModel>(dados);
        }
    }
}