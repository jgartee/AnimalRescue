using AnimalRescue.Core;

namespace AnimalRescue.Intake
{
    public class Intake
    {
        public Intake(IntakeId intakeId)
        {
            Id = intakeId;
        }

        public IntakeId Id { get; }
    }
}
