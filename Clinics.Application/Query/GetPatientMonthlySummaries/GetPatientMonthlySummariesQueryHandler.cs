using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Repository;

namespace Clinics.Application.Query.GetPatientMonthlySummaries
{
    internal sealed class GetPatientMonthlySummariesQueryHandler : IQueryHandler<GetPatientMonthlySummariesQuery, IEnumerable<PatientMonthlySummaryDTO>>
    {
        private readonly IPatientQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public GetPatientMonthlySummariesQueryHandler(IPatientQueryRepository queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientMonthlySummaryDTO>?> HandleAsync(GetPatientMonthlySummariesQuery query)
        {
            var patients = (await _queryRepository.GetAllPatientsWithSessionsAndPaymentsFilteredByYearAndMonthAsync(query.Year, query.Month))
                .OrderBy(a => a.Name).ToList();

            return patients.AsQueryable().ProjectTo<PatientMonthlySummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}