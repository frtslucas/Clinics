using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    public class SessionController : BaseAggregateRootController<AddSessionToPatientCommand, SessionDTO, SessionSummaryDTO>
    {
        public SessionController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpPost("Payment")]
        public async Task<IActionResult> AddPaymentAsync([FromBody] AddPaymentToSessionCommand command)
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
