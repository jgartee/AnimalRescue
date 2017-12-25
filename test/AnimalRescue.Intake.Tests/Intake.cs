using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake.Models
{
    public class Intake
    {
        public Intake(AnimalId animalId, StaffId staffId)
        {
            AnimalId = animalId;
            StaffId = staffId;
        }

        public AnimalId AnimalId { get; }
        public StaffId StaffId { get; }
    }
}
