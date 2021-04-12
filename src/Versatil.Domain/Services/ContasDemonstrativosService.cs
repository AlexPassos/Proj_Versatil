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
    public class ContasDemonstrativosService : BaseService, IContasDemonstrativosService
    {

        private readonly IMapper _mapper;
        private readonly IContasDemonstrativosRepository _demonstrativosRepository;

        public ContasDemonstrativosService(INotificador notificador,
                             IUser user,
                             IMapper mapper,
                             IContasDemonstrativosRepository demonstrativosRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _demonstrativosRepository = demonstrativosRepository;
        }

        public async Task<ContasDemonstrativosViewModel> GetDemonstrativoId(int id)
        {
            var dados = await _demonstrativosRepository.Get(x => x.id == id);
            return _mapper.Map<ContasDemonstrativosViewModel>(dados);
        }

        public async Task<IEnumerable<ContasDemonstrativosViewModel>> GetDemonstrativosAll()
        {
            var dados = await _demonstrativosRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.nome));
            return _mapper.Map<IEnumerable<ContasDemonstrativosViewModel>>(dados);
        }
    }
}