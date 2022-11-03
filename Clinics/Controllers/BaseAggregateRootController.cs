using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.GetAll;
using Clinics.Application.Query.GetById;
using Clinics.Application.Query.GetSummaries;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseAggregateRootController<TAddCommand, TDTO, TSummaryDTO> : ControllerBase
        where TAddCommand : class, ICreateCommand
        where TDTO : IAggregateRootDTO
        where TSummaryDTO : ISummaryDTO
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

        [HttpGet("Summaries")]
        public async Task<ActionResult<IEnumerable<TSummaryDTO>>> GetSummariesAsync([FromQuery] GetSummariesQuery<IEnumerable<TSummaryDTO>> query)
        {
            var result = await _queryDispatcher.QueryAsync<GetSummariesQuery<IEnumerable<TSummaryDTO>>, IEnumerable<TSummaryDTO>>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TAddCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = command.Id }, null);
        }
    }
}
