using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake.Models
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
