using MiCourt.PersonalProtection.Domain.Persons.Models;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class PersonBuilder
    {
        private PersonId _personId = PersonId.NewId();

        public Person Build()
        {
            var person = new Person(_personId);

            return person;
        }

        public PersonBuilder WithPersonId(PersonId personId)
        {
            _personId = personId;
            return this;
        }
    }
}