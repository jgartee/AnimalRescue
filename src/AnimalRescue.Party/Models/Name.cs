using System;

namespace AnimalRescue.Party.Models
{
    public class Name
    {
        public string FirstName { get; }
        public string MiddleName { get; }
        public string LastName { get; }

        public Name(string firstName, string middleName, string lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }
    }
}
