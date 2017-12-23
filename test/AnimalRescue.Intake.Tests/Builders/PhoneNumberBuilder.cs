using MiCourt.PersonalProtection.Domain.Common.Models;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class PhoneNumberBuilder
    {
        private string _extension = "543210";
        private string _areaCode = "810";
        private string _exchange = "688";
        private string _station = "1212";
        private string _countryCode = "+1";

        public PhoneNumber Build()
        {
            var phoneNumber = new PhoneNumber(_countryCode, _areaCode, _exchange, _station, _extension);

            return phoneNumber;
        }

        public PhoneNumberBuilder WithCountryCode(string countryCode)
        {
            _countryCode = countryCode;
            return this;
        }

        public PhoneNumberBuilder WithAreaCode(string areaCode)
        {
            _areaCode = areaCode;
            return this;
        }

        public PhoneNumberBuilder WithExchange(string exchange)
        {
            _exchange = exchange;
            return this;
        }

        public PhoneNumberBuilder WithStation(string station)
        {
            _station = station;
            return this;
        }

        public PhoneNumberBuilder WithExtension(string extension)
        {
            _extension = extension;
            return this;
        }
    }
}