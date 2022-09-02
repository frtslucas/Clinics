using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetAll
{
    internal class GetAllQueryHandler<TQueryModel, TDTO> : IQueryHandler<GetAllQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>>
        where TQueryModel : class, IQueryModel
        where TDTO : class, IAggregateRootDTO
    {
        private readonly IQueryProvider<TQueryModel> _queryProvider;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IQueryProvider<TQueryModel> queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>?> HandleAsync(GetAllQuery<IEnumerable<TDTO>> query)
        {
            return (await _queryProvider.GetAllAsync()).ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
