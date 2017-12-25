using System;

namespace AnimalRescue.Core
{
    public class StaffId : Id<Guid>
    {
        public StaffId(Guid value) : base(value)
        {
        }

        public static StaffId NewId()
        {
            return new StaffId(Guid.NewGuid());
        }
    }
}
