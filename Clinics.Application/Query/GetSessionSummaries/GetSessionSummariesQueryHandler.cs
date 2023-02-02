using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application.Query.GetSessionSummaries
{
    internal sealed class GetSessionSummariesQueryHandler : IQueryHandler<GetSessionSummariesQuery, IEnumerable<SessionSummaryDTO>>
    {
        private readonly IQueryProvider<SessionQueryModel> _queryProvider;
        private readonly IMapper _mapper;

        public GetSessionSummariesQueryHandler(IQueryProvider<SessionQueryModel> queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionSummaryDTO>?> HandleAsync(GetSessionSummariesQuery query)
        {
            return (await _queryProvider.GetAllAsync(a => a.Date.Year == query.Year && a.Date.Month == query.Month))
                .ProjectTo<SessionSummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
