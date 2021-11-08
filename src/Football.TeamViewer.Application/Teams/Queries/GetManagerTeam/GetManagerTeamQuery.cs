using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Football.TeamViewer.Application.Teams.Queries.GetManagerTeam
{
    public class GetManagerTeamQuery : IRequest<ManagerTeam>
    {
        public GetManagerTeamQuery(Guid managerId)
        {
            ManagerId = managerId;
        }
        
        public Guid ManagerId { get;  }

        public class GetManagerTeamQueryHandler : IRequestHandler<GetManagerTeamQuery, ManagerTeam>
        {
            private readonly ITeamRepository _repository;

            public GetManagerTeamQueryHandler(ITeamRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<ManagerTeam> Handle(GetManagerTeamQuery request, CancellationToken cancellationToken)
            {
                var team = await _repository.GetByManagerId(request.ManagerId);

                if (team == null)
                {
                    return null;
                }
                
                return new ManagerTeam(
                    team.Id, 
                    team.Name, 
                    new ManagerTeamCoach(team.Coach.Id, $"{team.Coach.FirstName} {team.Coach.SecondName}"),
                    team.Players?.Select(p => p.Id).ToArray() ?? Array.Empty<Guid>());
            }
        }
    }
}