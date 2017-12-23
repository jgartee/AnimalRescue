using FluentAssertions;
using AnimalRescue.Core.Extensions;
using Xunit;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace AnimalRescue.Core.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void GetCommandReturnType_WithGenericICommandImplementation_ReturnsICommandGenericType()
        {
            var command = new CreateThing("id");
            var result = command.GetCommandReturnType();

            result.Should().Be(typeof(string));
        }

        [Fact]
        public void GetCommandReturnType_WithNonGenericICommandImplementation_ReturnsNull()
        {
            var command = new UploadThingImage("id", "c:\\image.png");
            var result = command.GetCommandReturnType();

            result.Should().BeNull();
        }

        [Fact]
        public void GetQueryReturnType_WithGenericIQueryImplementation_ReturnsIQueryGenericType()
        {
            var query = new GetThing();
            var result = query.GetQueryReturnType();

            result.Should().Be(typeof(string));
        }

        public class CreateThing : ICommand<string>
        {
            public CreateThing(string id)
            {
                Id = id;
            }

            public string Id { get; }
        }

        public class UploadThingImage : ICommand
        {
            public UploadThingImage(string id, string imagePath)
            {
                Id = id;
                ImagePath = imagePath;
            }

            public string Id { get; }

            public string ImagePath { get; }
        }

        public class GetThing : IQuery<string>
        {
            public GetThing(string id = "test")
            {
                Id = id;
            }

            public string Id { get; }
        }
    }
}
