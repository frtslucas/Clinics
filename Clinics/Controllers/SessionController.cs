using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.Query.GetSessionSummaries;
using Clinics.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    public class SessionController : BaseAggregateRootController<SessionDTO>
    {
        public SessionController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("Summaries")]
        public async Task<ActionResult<IEnumerable<SessionSummaryDTO>>> GetSessionSummariesByMonthAsync([FromQuery] GetSessionSummariesQuery query)
        {
            var result = await _queryDispatcher.QueryAsync<GetSessionSummariesQuery, IEnumerable<SessionSummaryDTO>>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSessionToPatientAsync([FromBody] AddSessionToPatientCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = command.Id }, null);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPaymentToSessionAsync([FromBody] AddPaymentToSessionCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("MarkAsDone")]
        public async Task<IActionResult> MarkAsDone([FromBody] MarkSessionAsDoneCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
