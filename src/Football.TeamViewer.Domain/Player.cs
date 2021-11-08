using System;

namespace Football.TeamViewer.Domain
{
    public class Player
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string SecondName { get; set; }
        
        public int JerseyNumber { get; set; }
        
        public Team Team { get; set; }

    }
}