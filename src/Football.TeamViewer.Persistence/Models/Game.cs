using System;
using Football.TeamViewer.Domain;

namespace Football.TeamViewer.Persistence.Models
{
    public class Game
    {
        public Guid Id { get; set; }
    
        public Team FirstTeam { get; set; }
    
        public Team SecondTeam { get; set; }
    
        public int? FirstTeamScore { get; set; }
        
        public int? SecondTeamScore { get; set; }
    
        public DateTime? DateTime { get; set; }
    }
}