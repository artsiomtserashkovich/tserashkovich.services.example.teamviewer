using System;

namespace Football.TeamViewer.Domain
{
    public class Game
    {
        public Guid Id { get; set; }
        
        public Team FirstTeam { get; set; }
        
        public Team SecondTeam { get; set; }
        
        public GameResult Result { get; set; }
        
        public DateTime? DateTime { get; set; }
    }
}