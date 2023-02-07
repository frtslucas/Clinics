using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Providers;

namespace Clinics.Application.Query.GetPatientMonthlySummaries
{
    internal sealed class GetPatientMonthlySummariesQueryHandler : IQueryHandler<GetPatientMonthlySummariesQuery, IEnumerable<PatientMonthlySummaryDTO>>
    {
        private readonly IPatientQueryProvider _queryProvider;
        private readonly IMapper _mapper;

        public GetPatientMonthlySummariesQueryHandler(IPatientQueryProvider queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientMonthlySummaryDTO>?> HandleAsync(GetPatientMonthlySummariesQuery query)
        {
            var patients = (await _queryProvider.GetAllPatientsWithSessionsAndPaymentsFilteredByYearAndMonthAsync(query.Year, query.Month)).ToList();

            return patients.AsQueryable().ProjectTo<PatientMonthlySummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}