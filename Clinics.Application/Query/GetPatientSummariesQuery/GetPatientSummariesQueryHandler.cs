﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.DTOs;
using Clinics.Application.Query.Models.PatientAggregate;

namespace Clinics.Application.Query.GetPatientSummaries
{
    internal sealed class GetPatientSummariesQueryHandler : IQueryHandler<GetPatientSummariesQuery, IEnumerable<PatientSummaryDTO>>
    {
        private readonly IQueryProvider<PatientQueryModel> _queryProvider;
        private readonly IMapper _mapper;

        public GetPatientSummariesQueryHandler(IQueryProvider<PatientQueryModel> queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientSummaryDTO>?> HandleAsync(GetPatientSummariesQuery query)
        {
            return (await _queryProvider.GetAllAsync())
                .ProjectTo<PatientSummaryDTO>(_mapper.ConfigurationProvider).ToList();
        }
    }
}
