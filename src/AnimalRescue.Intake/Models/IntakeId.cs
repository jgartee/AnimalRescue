using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake
{
    public class IntakeId : Id<Guid>
    {
        public IntakeId(Guid value) : base(value)
        {
        }

        public static IntakeId NewId()
        {
            return new IntakeId(Guid.NewGuid());
        }
    }
}
