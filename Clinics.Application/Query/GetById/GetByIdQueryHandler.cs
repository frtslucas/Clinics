using AutoMapper;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetById
{
    internal class GetByIdQueryHandler<TQueryModel, TDTO> : IQueryHandler<GetByIdQuery<TDTO>, TDTO>
        where TQueryModel : class, IQueryModel
        where TDTO : class, IAggregateRootDTO
    {
        private readonly IQueryRepository<TQueryModel> _queryRepository;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IQueryRepository<TQueryModel> queryRepository, IMapper mapper)
        {
            _queryRepository = queryRepository;
            _mapper = mapper;
        }

        public async Task<TDTO?> HandleAsync(GetByIdQuery<TDTO> query)
        {
            var queryModel = await _queryRepository.GetByIdAsync(query.Id);
            return _mapper.Map<TDTO>(queryModel);
        }
    }
}
