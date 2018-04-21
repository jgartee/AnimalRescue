using System;

namespace AnimalRescue.Core
{
    public class AddressId : Id<Guid>
    {
        public AddressId(Guid value) : base(value)
        {

        }

        public static AddressId NewId()
        {
            return new AddressId(Guid.NewGuid());
        }
    }
}
