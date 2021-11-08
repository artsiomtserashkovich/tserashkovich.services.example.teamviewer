using System;
using System.Collections.Generic;

namespace Football.TeamViewer.Application.Teams.Queries.GetManagerTeam
{
    public class ManagerTeam
    {
        public ManagerTeam(Guid id, string name, ManagerTeamCoach coach, IReadOnlyCollection<Guid> playerIds)
        {
            Id = id;
            Name = name;
            PlayerIds = playerIds;
            Coach = coach;
        }

        public Guid Id { get; }
        
        public string Name { get; }
        
        public ManagerTeamCoach Coach { get; }
        
        public IReadOnlyCollection<Guid> PlayerIds { get; }
    }

    public class ManagerTeamCoach
    {
        public ManagerTeamCoach(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        
        public string Name { get; }
    }
}