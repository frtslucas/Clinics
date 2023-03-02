using AutoMapper;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Repository;

namespace Clinics.Application.Query.GetPatientByNameQuery
{
    internal sealed class GetPatientByNameQueryHandler : IQueryHandler<GetPatientByNameQuery, PatientDTO>
    {
        private readonly IPatientQueryRepository _patientQueryRepository;
        private readonly IMapper _mapper;

        public GetPatientByNameQueryHandler(IPatientQueryRepository patientQueryRepository, IMapper mapper)
        {
            _patientQueryRepository = patientQueryRepository;
            _mapper = mapper;
        }

        public async Task<PatientDTO?> HandleAsync(GetPatientByNameQuery query)
        {
            var patient = await _patientQueryRepository.GetPatientByNameAsync(query.Name);

            if (patient is null)
                return null;

            return _mapper.Map<PatientDTO>(patient);
        }
    }
}
