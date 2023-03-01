using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.InactivatePatient;
using Clinics.Application.Command.ReactivatePatient;
using Clinics.Application.Command.RegisterPatient;
using Clinics.Application.Command.SetAgreedValue;
using Clinics.Application.Query.GetPatientSummaries;
using Clinics.Application.Query.GetPatientMonthlySummaries;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseAggregateRootController<PatientDTO>
    {
        public PatientController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("Summaries")]
        public async Task<ActionResult<IEnumerable<PatientSummaryDTO>>> GetPatientSummariesAsync([FromQuery] GetPatientSummariesQuery query)
        {
            var result = await _queryDispatcher.QueryAsync<GetPatientSummariesQuery, IEnumerable<PatientSummaryDTO>>(query);
            return Ok(result);
        }

        [HttpGet("MonthlySummaries")]
        public async Task<ActionResult<IEnumerable<PatientSummaryDTO>>> GetPatientMonthlySummariesAsync([FromQuery] GetPatientMonthlySummariesQuery query)
        {
            var result = await _queryDispatcher.QueryAsync<GetPatientMonthlySummariesQuery, IEnumerable<PatientMonthlySummaryDTO>>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatientAsync([FromBody] RegisterPatientCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync<RegisterPatientCommand, Patient>(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = result.ReturnValue.Id }, null);
        }

        [HttpPut("AgreedValue")]
        public async Task<IActionResult> SetAgreedValueAsync([FromBody] SetAgreedValueCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync(command);

            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("Inactivate")]
        public async Task<IActionResult> InactivatePatientAsync([FromBody] InactivatePatientCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync(command);
            
            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPut("Reactivate")]
        public async Task<IActionResult> ReactivatePatientAsync([FromBody] ReactivatePatientCommand command)
        {
            var result = await _commandDispatcher.DispatchAsync(command);
            
            if (!result.IsValid)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
