using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Command.AddPaymentToSession;
using Clinics.Application.Command.AddSessionToPatient;
using Clinics.Application.Command.InactivatePatient;
using Clinics.Application.Command.MarkSessionAsDone;
using Clinics.Application.Command.ReactivatePatient;
using Clinics.Application.Command.RegisterPatient;
using Clinics.Application.Command.SetAgreedValue;
using Clinics.Application.DTOs;
using Clinics.Application.Query.GetAll;
using Clinics.Application.Query.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PatientController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet("{Id:guid}")]
        public async Task<ActionResult<PatientDTO>> GetByIdAsync([FromRoute] GetByIdQuery<PatientDTO> query)
        {
            var result = await _queryDispatcher.QueryAsync<GetByIdQuery<PatientDTO>, PatientDTO>(query);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAllAsync([FromQuery] GetAllQuery<IEnumerable<PatientDTO>> query)
        {
            var result = await _queryDispatcher.QueryAsync<GetAllQuery<IEnumerable<PatientDTO>>, IEnumerable<PatientDTO>>(query);
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

        [HttpPost("Session")]
        public async Task<IActionResult> AddSessionToPatientAsync([FromBody] AddSessionToPatientCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPost("Session/Payment")]
        public async Task<IActionResult> AddPaymentToSessionAsync([FromBody] AddPaymentToSessionCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPut("Session/MarkAsDone")]
        public async Task<IActionResult> MaskSessionAsDone([FromBody] MarkSessionAsDoneCommand command)
        {
            await _commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
