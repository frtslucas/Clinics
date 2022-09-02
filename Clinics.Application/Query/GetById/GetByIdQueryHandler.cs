using AutoMapper;
using Clinics.Application.Abstractions.Interfaces;

namespace Clinics.Application.Query.GetById
{
    internal class GetByIdQueryHandler<TQueryModel, TDTO> : IQueryHandler<GetByIdQuery<TDTO>, TDTO>
        where TQueryModel : class, IQueryModel
        where TDTO : class, IAggregateRootDTO
    {
        private readonly IQueryProvider<TQueryModel> _queryProvider;
        private readonly IMapper _mapper;

        public GetByIdQueryHandler(IQueryProvider<TQueryModel> queryProvider, IMapper mapper)
        {
            _queryProvider = queryProvider;
            _mapper = mapper;
        }

        public async Task<TDTO?> HandleAsync(GetByIdQuery<TDTO> query)
        {
            var queryModel = await _queryProvider.GetByIdAsync(query.Id);
            return _mapper.Map<TDTO>(queryModel);
        }
    }
}
