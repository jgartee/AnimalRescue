using System.Collections.Generic;
using System.Security.Claims;

namespace AnimalRescue.Intake.Tests.Builders
{
    public class ClaimsPrincipalBuilder
    {
        private readonly List<ClaimsIdentity> _identities = new List<ClaimsIdentity>();

        public ClaimsPrincipalBuilder WithIdentity(ClaimsIdentityBuilder builder)
        {
            return WithIdentity(builder.Build());
        }

        public ClaimsPrincipalBuilder WithIdentity(ClaimsIdentity identity)
        {
            _identities.Add(identity);
            return this;
        }

        public ClaimsPrincipal Build()
        {
            return new ClaimsPrincipal(_identities);
        }

        public static ClaimsPrincipal Default()
        {
            return new ClaimsPrincipalBuilder()
                .WithIdentity(new ClaimsIdentityBuilder())
                .Build();
        }
    }
}
