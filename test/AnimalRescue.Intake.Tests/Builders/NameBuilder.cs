using MiCourt.PersonalProtection.Domain.Common.Models;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class NameBuilder
    {
        private string _firstName = "any-first-name";
        private string _lastName = "any-last-name";
        private string _middleName = "any-middle-name";

        public Name Build()
        {
            var name = new Name(_firstName, _middleName, _lastName);

            return name;
        }

        public NameBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public NameBuilder WithMiddleName(string middleName)
        {
            _middleName = middleName;
            return this;
        }

        public NameBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }
    }
}