using System;

namespace AnimalRescue.Core
{
    public class OrganizationId : Id<Guid>
    {
        public OrganizationId(Guid value) : base(value)
        {
        }
         public static OrganizationId NewId()
         {
             return new OrganizationId(Guid.NewGuid());
         }
    }
}
