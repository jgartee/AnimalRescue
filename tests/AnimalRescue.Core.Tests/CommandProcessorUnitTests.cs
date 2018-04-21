using System;
using System.Security.Claims;
using System.Threading.Tasks;
using FluentAssertions;
using AnimalRescue.Core.Exceptions;
using CommonServiceLocator;
using NSubstitute;
using Xunit;
using Xunit.Abstractions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable PossibleNullReferenceException
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace AnimalRescue.Core.Tests
{
    public class CommandProcessorUnitTests
    {
        private readonly ITestOutputHelper _output;

        public CommandProcessorUnitTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task ProcessAsync_WithNoRegisteredCommandHandler_Throws()
        {
            var serviceLocator = Substitute.For<IServiceLocator>();
            var commandProcessor = new CommandProcessor(serviceLocator);

            var exception = await Record.ExceptionAsync(() => commandProcessor.ProcessAsync(new TestCommand()));
            exception.Should().BeOfType<CommandHandlerNotRegisteredException>();

            _output.WriteLine(exception.Message);
        }

        [Fact]
        public async Task ProcessAsync_WithNullCommand_Throws()
        {
            var serviceLocator = Substitute.For<IServiceLocator>();
            var commandProcessor = new CommandProcessor(serviceLocator);

            var exception = await Record.ExceptionAsync(() => commandProcessor.ProcessAsync(null));
            exception.Should().BeOfType<GuardException>();

            _output.WriteLine(exception.Message);
        }

        [Fact]
        public async Task ProcessAsync_WithRegisteredHandler_ExecutesHandler()
        {
            var handler = new TestCommandWithResultHandler();

            var serviceLocator = Substitute.For<IServiceLocator>();
            serviceLocator.GetInstance(typeof(ICommandHandler<TestCommandWithResult, TestResult>))
                .Returns(handler);

            var commandProcessor = new CommandProcessor(serviceLocator);
            var result = await commandProcessor.ProcessAsync(new TestCommandWithResult("1"));

            result.Should().Be(new TestResult("1"));
        }

        [Fact]
        public async Task ProcessAsync_WithRegisteredHandlerAndNoResultReturned_ExecutesHandler()
        {
            var handlerWasCalled = false;
            var handler = new TestCommandHandler(() => handlerWasCalled = true);

            var serviceLocator = Substitute.For<IServiceLocator>();
            serviceLocator.GetInstance(typeof(ICommandHandler<TestCommand>))
                .Returns(handler);

            var commandProcessor = new CommandProcessor(serviceLocator);
            await commandProcessor.ProcessAsync(new TestCommand());

            handlerWasCalled.Should().BeTrue();
        }

        public class TestCommand : ICommand
        {
        }

        public class TestCommandHandler : ICommandHandler<TestCommand>
        {
            private readonly Action _actionWhenCalled;

            public TestCommandHandler(Action actionWhenCalled)
            {
                _actionWhenCalled = actionWhenCalled;
            }

            public async Task HandleAsync(TestCommand command, ClaimsPrincipal user)
            {
                _actionWhenCalled?.Invoke();
            }
        }

        public class TestCommandWithResult : ICommand<TestResult>
        {
            public TestCommandWithResult(string value)
            {
                Value = value;
            }

            public string Value { get; }
        }

        public class TestCommandWithResultHandler : ICommandHandler<TestCommandWithResult, TestResult>
        {
            public async Task<TestResult> HandleAsync(TestCommandWithResult command, ClaimsPrincipal user)
            {
                return new TestResult(command.Value);
            }
        }

        public class TestResult
        {
            public TestResult(string value)
            {
                Value = value;
            }

            public string Value { get; }

            private bool Equals(TestResult other)
            {
                return string.Equals(Value, other.Value);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                return obj.GetType() == GetType() && Equals((TestResult) obj);
            }

            public override int GetHashCode()
            {
                return Value?.GetHashCode() ?? 0;
            }
        }
    }
}
