using System;
using System.Threading.Tasks;
using System.Security.Claims;
using Autofac;
using Autofac.Extras.CommonServiceLocator;

using AnimalRescue.Core;
using AnimalRescue.Core.Exceptions;
using AnimalRescue.Intake.Models;
using AnimalRescue.Intake.Commands;

using Xunit;
using Xunit.Abstractions;
using Xunit.Ioc.Autofac;
using FluentAssertions;
using AutofacContrib.NSubstitute;

using NSubstitute;
using System.Diagnostics.Contracts;
using CreateIntake = AnimalRescue.Intake.Commands.CreateIntake;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PossibleNullReferenceException
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace AnimalRescue.Intake.Tests.Commands
{

    [UseAutofacTestFramework]
    [Collection("Intake Integration Tests")]
    [Trait("Category", "Integration")]

    public class CommandProcessorTests
    {
 		[Fact]
private async Task CreateIntakeCommand_CallsIntakeCommandHandler()
        {
            Contract.Ensures(Contract.Result<Task>() != null);
            var autoSubstitute = new AutoSubstitute();
			var serviceLocator = CommonServiceLocator.ServiceLocator.Current;

            //var handler = serviceLocator.GetInstance(typeof(ICommandHandler<IntakeCreated, IntakeInfo>));
			var intake = new Intake( IntakeId.NewId() );
			var result = new CreateIntake(intake);

            var command = new IntakeCommand(IntakeId.NewId());
            var handler = new IntakeCreatedHandler();

            autoSubstitute
                .Provide<CreateIntake, Models.CreateIntake>(command);
            autoSubstitute
                .Provide(handler);

            autoSubstitute
                .Resolve<ICommandProcessor>(Arg.Equals(serviceLocator))
                .ProcessAsync(Arg.Any<CreateIntake>(), Arg.Any<ClaimsPrincipal>())
                .Returns(c => c.Arg<CreateIntake>());


            Assert.IsType<Models.CreateIntake>(result);
        }
    }
}
