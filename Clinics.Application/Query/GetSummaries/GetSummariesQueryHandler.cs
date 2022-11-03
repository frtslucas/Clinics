using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetSummaries
{
    internal sealed class GetSummariesQueryHandler<TQueryModel, TDTO> : IQueryHandler<GetSummariesQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>>
        where TQueryModel : class, IQueryModel
        where TDTO : class, ISummaryDTO
    {
        private readonly IQueryProvider<TQueryModel> _queryProvider;
        private readonly IMapper _mapper;

        public GetSummariesQueryHandler(IQueryProvider<TQueryModel> queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDTO>?> HandleAsync(GetSummariesQuery<IEnumerable<TDTO>> query)
        {
            return (await _queryProvider.GetAllAsync()).ProjectTo<TDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
