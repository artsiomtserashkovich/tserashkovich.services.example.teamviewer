using System;

namespace Football.TeamViewer.Domain
{
    // TODO: encapsulate assigning of variables into ctor
    // introduce methods instead of setters for changing of the object's state (fields values) 
    public class Coach
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string SecondName { get; set; }
        
        public Team Team { get; set; }
    }
}