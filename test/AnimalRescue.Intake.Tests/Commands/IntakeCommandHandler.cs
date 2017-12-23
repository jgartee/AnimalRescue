using System.Net;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NodaTime;

using Xunit;
using Xunit.Abstractions;
using FluentAssertions;

using AnimalRescue.Intake.Models;

namespace AnimalRescue.Intake.Tests.Commands
{

    [Collection("Intake Integration Tests")]
    [Trait("Category", "Integration")]

    public class IntakeCommandHandlerTests
    {
        private readonly ITestOutputHelper _output;

        public IntakeCommandHandlerTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task GivenIntakeDoesNotExist_WhenIntakeCreated_CreatesNewIntake()
        {
            var intakeId = IntakeId.NewId();
            var animalId = AnimalId.NewId();
            var now = SystemClock.Instance.GetCurrentInstant();
            var staffMember 
        }
    }

}
