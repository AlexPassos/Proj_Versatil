using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.Interfaces.Services;

namespace Versatil.Domain.Services
{
    public class CidadesService : ICidadesService
    {

        private readonly IMapper _mapper;
        private readonly ICidadesRepository _cidadesRepository;

        public CidadesService(IMapper mapper, ICidadesRepository cidadesRepository)
        {
            _mapper = mapper;
            _cidadesRepository = cidadesRepository;
        }

        public async Task<IEnumerable<Cidades>> GetCidadesAll()
        {
            return await _cidadesRepository.GetMany(x => true, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.nome));
        }

        public async Task<Cidades> GetCidadeId(int id)
        {
            var dados = await _cidadesRepository.Get(x => x.id == id);
            return dados;
        }

        public async Task<IEnumerable<Cidades>> GetCidades(int id)
        {
            var dados = await _cidadesRepository.GetMany(x => x.ufID == id, expressionIncludes: null, orderBy: o => o.OrderBy(y => y.nome));
            return dados;
        }
    }
}