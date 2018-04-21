using System;

namespace AnimalRescue.Core
{
    public class PersonId : Id<Guid>
    {
        public PersonId(Guid value) : base(value)
        {
        }
         public static PersonId NewId()
         {
             return new PersonId(Guid.NewGuid());
         }
    }
}
