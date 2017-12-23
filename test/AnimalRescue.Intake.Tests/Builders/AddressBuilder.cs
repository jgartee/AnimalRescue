using AnimalRescue.Intake.Models;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class AddressBuilder
    {
        private string _addressLine1 = "123 North North St";
        private string _addressLine2 = "Suite 10000";
        private string _city = "Otter Lake";
        private string _country = "US";
        private string _state = "MI";
        private string _zipCode = "48464";

        public Address Build()
        {
            var address = new Address(_addressLine1, _addressLine2, _city, _state, _zipCode, _country);

            return address;
        }

        public AddressBuilder WithAddressLine1(string addressLine1)
        {
            _addressLine1 = addressLine1;
            return this;
        }

        public AddressBuilder WithAddressLine2(string addressLine2)
        {
            _addressLine2 = addressLine2;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public AddressBuilder WithZipCode(string zipCode)
        {
            _zipCode = zipCode;
            return this;
        }

        public AddressBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }
    }
}
