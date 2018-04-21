using System;
using System.Threading.Tasks;
using System.Security.Claims;

using AnimalRescue.Core;
using AnimalRescue.Intake.Models;

namespace AnimalRescue.Intake.Commands
{
    public class IntakeCreatedHandler : ICommandHandler<CreateIntake, Models.Intake>
    {
        public Task<Models.Intake> HandleAsync(CreateIntake command, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
