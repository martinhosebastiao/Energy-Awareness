using System;
using FluentAssertions;
using EA.Domain.Core.Users;

namespace EA.Domain.Tests.Users
{
	public class UserTests
	{
		[Fact]
		public void Create_Should_Return_User_When_Name_IsValid()
		{
			// Arrange
			var name = new Name("Diogo Mila");

			// Act
			var user = User.Create(name);

			// Assert
			user.Should().NotBeNull();
		}

        [Fact]
        public void Create_Should_RaiseDomainEvent_When_Name_IsValid()
        {
            // Arrange
            var name = new Name("Diogo Mila");

            // Act
            var user = User.Create(name);

            // Assert
            user.DomainEvents.Should().ContainSingle()
							 .Which.Should()
							 .BeOfType<UserCreatedDomainEvent>();
        }
    }
}

