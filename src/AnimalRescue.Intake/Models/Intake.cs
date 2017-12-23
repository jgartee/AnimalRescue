using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake.Models
{
    public class Intake
    {

        public Intake(AnimalId animalId)
        {
            AnimalId = animalId;
        }

        public AnimalId AnimalId { get; }
    }
}
