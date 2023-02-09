using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Repository;

namespace Clinics.Application.Query.GetPatientSummaries
{
    internal sealed class GetPatientSummariesQueryHandler : IQueryHandler<GetPatientSummariesQuery, IEnumerable<PatientSummaryDTO>>
    {
        private readonly IPatientQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public GetPatientSummariesQueryHandler(IPatientQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientSummaryDTO>?> HandleAsync(GetPatientSummariesQuery query)
        {
            return (await _queryRepository.GetAllAsync())
                .ProjectTo<PatientSummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
