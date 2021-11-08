using System;
using System.Collections.Generic;

namespace Football.TeamViewer.Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public Guid ManagerId { get; set; }
        
        public Coach Coach { get; set; }
        
        public IReadOnlyCollection<Player> Players { get; set; }
    }
}