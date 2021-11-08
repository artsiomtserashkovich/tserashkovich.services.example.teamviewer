using System;
using System.Threading;
using System.Threading.Tasks;
using Football.TeamViewer.Domain;
using MediatR;

namespace Football.TeamViewer.Application.Players.Commands.AddPlayerToManagerTeam
{
    public class AddPlayerToManagerTeamCommand : IRequest<bool>
    {
        public AddPlayerToManagerTeamCommand(Guid managerId, string firstName, string secondName, int jerseyNumber)
        {
            ManagerId = managerId;
            FirstName = firstName;
            SecondName = secondName;
            JerseyNumber = jerseyNumber;
        }

        public Guid ManagerId { get; }
        
        public string FirstName { get; }
        
        public string SecondName { get; }
        
        public int JerseyNumber { get; }
        
        public class AddPlayerToManagerTeamCommandHandler : IRequestHandler<AddPlayerToManagerTeamCommand, bool>
        {
            private readonly IPlayerRepository _repository;

            public AddPlayerToManagerTeamCommandHandler(IPlayerRepository repository)
            {
                _repository = repository;
            }
            
            public async Task<bool> Handle(AddPlayerToManagerTeamCommand request, CancellationToken cancellationToken)
            {
                var player = new Player
                {
                    FirstName = request.FirstName,
                    SecondName = request.SecondName,
                    JerseyNumber = request.JerseyNumber
                };
                
                return await _repository.Create(request.ManagerId, player);
            }
        }
    }
}