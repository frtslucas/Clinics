using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.ProcessPatientPayment;
using Clinics.Application.DTOs;
using Clinics.Application.Query.GetById;
using Clinics.Domain.Aggregates.PaymentAggregate;
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
            var result = await _commandDispatcher.DispatchAsync<ProcessPatientPaymentCommand, Payment>(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetByIdAsync), new GetByIdQuery<Payment> { Id = result.ReturnValue.Id.Value }, null);
        }
    }
}
