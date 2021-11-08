using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Football.TeamViewer.Application.Players.Queries.GetManagerTeamPlayers
{
    public class GetManagerTeamPlayersQuery : IRequest<IReadOnlyCollection<ManagerTeamPlayer>>
    {
        public GetManagerTeamPlayersQuery(Guid managerId)
        {
            ManagerId = managerId;
        }

        public Guid ManagerId { get; }
        
        public class CreateManagerTeamCommandHandler : IRequestHandler<GetManagerTeamPlayersQuery, IReadOnlyCollection<ManagerTeamPlayer>>
        {
            private readonly IPlayerRepository _repository;

            public CreateManagerTeamCommandHandler(IPlayerRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<ManagerTeamPlayer>> Handle(GetManagerTeamPlayersQuery request, CancellationToken cancellationToken)
            {
                var players = await _repository.GetByManagerId(request.ManagerId);

                return players?
                    .Select(p => new ManagerTeamPlayer(p.Id, $"{p.FirstName} {p.SecondName}", p.JerseyNumber))
                    .ToArray();
            }
        }
    }
}