using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.Query.GetSessionSummaries;
using Clinics.Application.DTOs;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Application.Query.GetById;
using Clinics.Application.Command.EditSessionDate;
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
            var result = await _commandDispatcher.DispatchAsync<AddSessionToPatientCommand, Session>(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetByIdAsync), new GetByIdQuery<Session>() { Id = result.ReturnValue.Id.Value }, result.ReturnValue);
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPaymentToSessionAsync([FromBody] AddPaymentToSessionCommand command)
        {
            var result =  await _commandDispatcher.DispatchAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("MarkAsDone")]
        public async Task<IActionResult> MarkAsDone([FromBody] MarkSessionAsDoneCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("EditDate")]
        public async Task<IActionResult> EditDate([FromBody] EditSessionDateCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
