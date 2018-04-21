using System;
using AnimalRescue.Core;

namespace AnimalRescue.Intake.Models
{
    public class Intake
    {
        public IntakeId IntakeId { get; }

        public Intake(IntakeId intakeId)
        {
            IntakeId = intakeId;
        }
    }
}
