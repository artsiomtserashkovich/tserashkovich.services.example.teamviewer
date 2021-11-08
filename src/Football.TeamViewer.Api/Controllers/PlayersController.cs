using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Football.TeamViewer.Application.Players.Commands.AddPlayerToManagerTeam;
using Football.TeamViewer.Application.Players.Queries.GetManagerTeamPlayers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Football.TeamViewer.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    // TODO: Role or policy based authorization to allow only manager of team
    [Authorize]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get([Required] Guid playerId)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var managerId = Guid.NewGuid(); // TODO: Get manager id from Claims
            var result = await _mediator.Send(new GetManagerTeamPlayersQuery(managerId));

            if (result is null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlayerModel model)
        {
            var managerId = Guid.NewGuid(); // TODO: Get manager id from Claims
            var request = new AddPlayerToManagerTeamCommand(
                managerId,
                model?.FirstName,
                model?.SecondName,
                model?.JerseyNumber ?? default);
            
            var result = await _mediator.Send(request);

            return result
                ? new OkResult(/* TODO: If result is success return Id of new record and return as OK response*/)
                : new BadRequestResult( /* TODO: throw from Application layer the reason why model cannot be created*/);
        }
    }

    public class CreatePlayerModel
    {
        public string FirstName { get; }
        
        public string SecondName { get; }
        
        public int JerseyNumber { get; }
    }
}