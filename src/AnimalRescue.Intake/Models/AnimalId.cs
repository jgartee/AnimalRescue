using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake.Models
{
    public class AnimalId : Id<Guid>
    {
        public AnimalId(Guid value) : base(value)
        {
        }

        public static AnimalId NewId()
        {
            return new AnimalId(Guid.NewGuid());
        }
    }
}