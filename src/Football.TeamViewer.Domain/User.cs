using System;

namespace Football.TeamViewer.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }
        
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }
    }
}