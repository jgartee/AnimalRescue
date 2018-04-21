using System;
using AnimalRescue.Core;
using AnimalRescue.Intake.Models;

namespace AnimalRescue.Intake.Commands
{
    public class CreateIntakeCommand : ICommand<Models.Intake>
    {
        public Intake Intake { get; }

        public CreateIntakeCommand(Intake intake)
        {
            Intake = intake;
        }
    }
}
