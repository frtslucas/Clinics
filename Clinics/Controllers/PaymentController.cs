using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.ProcessPatientPayment;
using Clinics.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseAggregateRootController<PaymentDTO>
    {
        public PaymentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPatientPaymentAsync([FromBody] ProcessPatientPaymentCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = command.Id }, null);
        }
    }
}
