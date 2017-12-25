using AnimalRescue.Core;

namespace AnimalRescue.Party
{
    public class Person
    {
        public PersonId Id { get; }

        public Person(PersonId id)
        {
            Id = id;
        }
    }
}
