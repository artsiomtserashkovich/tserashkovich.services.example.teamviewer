using System;
using System.Threading.Tasks;
using Football.TeamViewer.Application.Teams.Commands.CreateManagerTeam;
using Football.TeamViewer.Application.Teams.Queries.GetManagerTeam;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football.TeamViewer.Api.Controllers
{
    [Route("api/team")]
    [ApiController]
    // TODO: Role or policy based authorization to allow only manager of team
    [Authorize]
    public class TeamController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var managerId = Guid.NewGuid(); // TODO: Get manager id from Claims
            var result = await _mediator.Send(new GetManagerTeamQuery(managerId));

            return result == null ? new NotFoundResult() : new OkObjectResult(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTeamModel model)
        {
            var managerId = Guid.NewGuid(); // TODO: Get manager id from Claims
            var result = await _mediator.Send(new CreateManagerTeamCommand(managerId, model?.Name));

            return result
                ? new OkResult(/* TODO: If result is success return Id of new record and return as OK response*/)
                : new BadRequestResult( /* TODO: throw from Application layer the reason why model cannot be created*/);
        }
        
        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }

    public class CreateTeamModel
    {
        public string Name { get; set; }
    }
}