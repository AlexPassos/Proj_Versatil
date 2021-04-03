using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Versatil.Domain.Entities;
using Versatil.Domain.Interfaces;
using Versatil.Domain.Interfaces.Repositories;
using Versatil.Domain.Interfaces.Services;

namespace Versatil.Domain.Services
{
    public class UfService : BaseService, IUfService
    {

        private readonly IMapper _mapper;
        private readonly IUfRepository _ufRepository;

        public UfService(INotificador notificador,
                         IUser user,
                         IMapper mapper,
                         IUfRepository ufRepository) : base(notificador, user)
        {
            _mapper = mapper;
            _ufRepository = ufRepository;
        }

        public async Task<IEnumerable<Uf>> GetUfAll()
        {
            return await _ufRepository.GetMany(x => true, expressionIncludes: null, orderBy: x => x.OrderBy(y => y.sigla));
        }

        public async Task<Uf> GetUfId(int id)
        {
            var dados = await _ufRepository.Get(x => x.id == id);
            return dados;
        }
    }
}