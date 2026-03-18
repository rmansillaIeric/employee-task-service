using EmployeeTaskService.Application.Commands.Teams.CreateTeam;
using EmployeeTaskService.Application.Queries.Teams.GetTeamById;
using EmployeeTaskService.Application.Queries.Teams.GetTeams;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTeamCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetTeamsQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTeamByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}