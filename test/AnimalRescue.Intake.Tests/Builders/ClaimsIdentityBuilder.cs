using System.Collections.Generic;
using System.Security.Claims;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class ClaimsIdentityBuilder
    {
        private string _nameType;
        private string _roleType;
        private readonly List<Claim> _claims = new List<Claim>();

        public ClaimsIdentityBuilder WithNameType(string nameType)
        {
            _nameType = nameType;
            return this;
        }
        public ClaimsIdentityBuilder WithRoleType(string roleType)
        {
            _roleType = roleType;
            return this;
        }

        public ClaimsIdentityBuilder WithClaim(Claim claim)
        {
            _claims.Add(claim);
            return this;
        }

        public ClaimsIdentity Build()
        {
            return new ClaimsIdentity(_claims);
        }
    }
}
