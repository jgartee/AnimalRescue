using System;
using AnimalRescue.Core;
using AnimalRescue.Core.Exceptions;

namespace AnimalRescue.Intake.Models
{
    public class PhoneNumber
    {
        public PhoneNumber(string countryCode, string areaCode, string exchange, string station, string extension)
        {
            CountryCode = countryCode;
            AreaCode = areaCode;
            Exchange = exchange;
            Station = station;
            Extension = extension;
        }

        public PhoneNumber(string countryCode, string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        public string CountryCode { get; private set; }
        public string AreaCode { get; private set; }
        public string Exchange { get; private set; }
        public string Station { get; private set; }

        public string Extension { get; private set; }
        public string Number { get; private set; }
    }
}

private static class Guard
{
    public static void IsNotNullCountryCode(string countryCode)
    {
        if( countryCode == null)
            throw new GuardException("Phone country code cannot be null");
    }
}
