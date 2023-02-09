using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetAll
{
    internal class GetAllQueryHandler<TQueryModel, TDTO> : IQueryHandler<GetAllQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>>
        where TQueryModel : class, IQueryModel
        where TDTO : class, IAggregateRootDTO
    {
        private readonly IQueryRepository<TQueryModel> _queryRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IQueryRepository<TQueryModel> queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>?> HandleAsync(GetAllQuery<IEnumerable<TDTO>> query)
        {
            return (await _queryRepository.GetAllAsync()).ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
