using System;
using System.Threading;
using System.Threading.Tasks;
using Football.TeamViewer.Domain;
using MediatR;

namespace Football.TeamViewer.Application.Teams.Commands.CreateManagerTeam
{
    public class CreateManagerTeamCommand : IRequest<bool>
    {
        public CreateManagerTeamCommand(Guid managerId, string name)
        {
            ManagerId = managerId;
            Name = name;
        }

        public Guid ManagerId { get; }
        
        public string Name { get; }
        
        public class CreateManagerTeamCommandHandler : IRequestHandler<CreateManagerTeamCommand, bool>
        {
            private readonly ITeamRepository _repository;

            public CreateManagerTeamCommandHandler(ITeamRepository repository)
            {
                _repository = repository;
            }

            public async Task<bool> Handle(CreateManagerTeamCommand request, CancellationToken cancellationToken)
            {
                var team = new Team
                {
                    Name = request.Name,
                    ManagerId = request.ManagerId
                };
                
                return await _repository.CreateIfManagerNotHas(team);
            }
        }
    }
}