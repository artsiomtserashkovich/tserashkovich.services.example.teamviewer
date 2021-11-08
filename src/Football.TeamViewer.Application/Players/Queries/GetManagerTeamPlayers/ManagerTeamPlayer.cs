using System;

namespace Football.TeamViewer.Application.Players.Queries.GetManagerTeamPlayers
{
    public class ManagerTeamPlayer
    {
        public ManagerTeamPlayer(Guid id, string name, int jerseyNumber)
        {
            Id = id;
            Name = name;
            JerseyNumber = jerseyNumber;
        }

        public Guid Id { get; }
        
        public string Name { get; }
        
        public int JerseyNumber { get; }
    }
}