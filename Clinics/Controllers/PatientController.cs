using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.InactivatePatient;
using Clinics.Application.Command.ReactivatePatient;
using Clinics.Application.Command.RegisterPatient;
using Clinics.Application.Command.SetAgreedValue;
using Clinics.Application.Query.GetPatientSummaries;
using Clinics.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : BaseAggregateRootController<PatientDTO, PatientSummaryDTO>
    {
        public PatientController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("Summaries")]
        public async Task<ActionResult<IEnumerable<PatientSummaryDTO>>> GetPatientSummariesByMonthAsync([FromQuery] GetPatientSummariesQuery query)
        {
            var result = await _queryDispatcher.QueryAsync<GetPatientSummariesQuery, IEnumerable<PatientSummaryDTO>>(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatientAsync([FromBody] RegisterPatientCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = command.Id }, null);
        }

        [HttpPut("AgreedValue")]
        public async Task<IActionResult> SetAgreedValueAsync([FromBody] SetAgreedValueCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("Inactivate")]
        public async Task<IActionResult> InactivatePatientAsync([FromBody] InactivatePatientCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("Reactivate")]
        public async Task<IActionResult> ReactivatePatientAsync([FromBody] ReactivatePatientCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
