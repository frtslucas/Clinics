using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.SessionAggregate;

namespace Clinics.Application.Query.GetSessionSummaries
{
    internal sealed class GetSessionSummariesQueryHandler : IQueryHandler<GetSessionSummariesQuery, IEnumerable<SessionSummaryDTO>>
    {
        private readonly IQueryRepository<SessionQueryModel> _queryRepository;
        private readonly IMapper _mapper;

        public GetSessionSummariesQueryHandler(IQueryRepository<SessionQueryModel> queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SessionSummaryDTO>?> HandleAsync(GetSessionSummariesQuery query)
        {
            return (await _queryRepository.GetAllAsync(a => a.Date.Year == query.Year && a.Date.Month == query.Month))
                .OrderBy(a => a.Date)
                .ProjectTo<SessionSummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
