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
    public class QueryProcessorUnitTests
    {
        private readonly ITestOutputHelper _output;

        public QueryProcessorUnitTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task ProcessAsync_WithNoRegisteredQueryHandler_Throws()
        {
            var serviceLocator = Substitute.For<IServiceLocator>();
            var queryProcessor = new QueryProcessor(serviceLocator);

            var exception = await Record.ExceptionAsync(() => queryProcessor.ProcessAsync(new TestQuery("1")));
            exception.Should().BeOfType<QueryHandlerNotRegisteredException>();

            _output.WriteLine(exception.Message);
        }

        [Fact]
        public async Task ProcessAsync_WithNullQuery_Throws()
        {
            var serviceLocator = Substitute.For<IServiceLocator>();
            var queryProcessor = new QueryProcessor(serviceLocator);

            var exception = await Record.ExceptionAsync(() => queryProcessor.ProcessAsync(null));
            exception.Should().BeOfType<GuardException>();

            _output.WriteLine(exception.Message);
        }

        [Fact]
        public async Task ProcessAsync_WithRegisteredHandler_ExecutesHandler()
        {
            var handler = new TestQueryHandler();

            var serviceLocator = Substitute.For<IServiceLocator>();
            serviceLocator.GetInstance(typeof(IQueryHandler<TestQuery, TestResult>))
                .Returns(handler);

            var queryProcessor = new QueryProcessor(serviceLocator);
            var result = await queryProcessor.ProcessAsync(new TestQuery("1"));

            result.Should().Be(new TestResult("1"));
        }

        public class TestQuery : IQuery<TestResult>
        {
            public TestQuery(string value)
            {
                Value = value;
            }

            public string Value { get; }
        }

        public class TestQueryHandler : IQueryHandler<TestQuery, TestResult>
        {
            public async Task<TestResult> HandleAsync(TestQuery query, ClaimsPrincipal user)
            {
                return new TestResult(query.Value);
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
