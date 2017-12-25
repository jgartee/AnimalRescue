using System;

namespace AnimalRescue.Core
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