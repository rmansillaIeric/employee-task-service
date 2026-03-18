using EmployeeTaskService.Application.Commands.Employees.CreateEmployee;
using EmployeeTaskService.Application.Commands.Employees.DeactivateEmployee;
using EmployeeTaskService.Application.Commands.Employees.UpdateEmployee;
using EmployeeTaskService.Application.Queries.Employees.GetEmployeeById;
using EmployeeTaskService.Application.Queries.Employees.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetEmployeesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(EmployeeDetailDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEmployeeCommand command)
        {
            if (id != command.Id)
                return BadRequest("El id de la ruta no coincide con el id del body.");

            var updated = await _mediator.Send(command);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpPatch("{id:guid}/deactivate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Deactivate(Guid id)
        {
            var deactivated = await _mediator.Send(new DeactivateEmployeeCommand(id));

            if (!deactivated)
                return NotFound();

            return NoContent();
        }


    }
}