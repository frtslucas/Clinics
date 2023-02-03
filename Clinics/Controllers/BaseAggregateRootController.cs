using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.GetAll;
using Clinics.Application.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseAggregateRootController<TDTO> : ControllerBase
        where TDTO : IAggregateRootDTO
    {
        protected readonly ICommandDispatcher _commandDispatcher;
        protected readonly IQueryDispatcher _queryDispatcher;

        public BaseAggregateRootController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<TDTO>> GetByIdAsync([FromRoute] GetByIdQuery<TDTO> query)
        {
            var result = await _queryDispatcher.QueryAsync<GetByIdQuery<TDTO>, TDTO>(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TDTO>>> GetAllAsync([FromQuery] GetAllQuery<IEnumerable<TDTO>> query)
        {
            var result = await _queryDispatcher.QueryAsync<GetAllQuery<IEnumerable<TDTO>>, IEnumerable<TDTO>>(query);
            return Ok(result);
        }
    }
}
