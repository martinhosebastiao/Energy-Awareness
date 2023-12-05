using EA.Domain.Core.Users;
using FluentAssertions;

namespace EA.Domain.Tests.Users
{
    public class NameTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_Should_ThrowArgumentException_When_ValueIsInvalid(string? value)
        {
            //Arrange


            //Act
            Name Action() => new(value);

            //Assert
            FluentActions.Invoking(Action).Should().ThrowExactly<ArgumentException>()
                         .Which.ParamName
                         .Should()
                         .Be("value");
        }
    }
}

