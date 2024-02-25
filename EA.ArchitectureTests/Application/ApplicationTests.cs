using System;
using FluentAssertions;
using NetArchTest.Rules;

namespace EA.ArchitectureTests.Application
{
	public class ApplicationTests: BaseTest
	{
		[Fact()]
		public void Handlers_Should_Have_Dependency_On_Domain()
		{
			//Arrange

			// Act
			var result = Types.InAssembly(ApplicationAssemblyReference)
							  .That()
							  .HaveNameEndingWith("Handler")
							  .Should()
							  .HaveDependencyOn(DomainNamespace)
							  .GetResult();

			// Assert
			result.IsSuccessful.Should().BeTrue();
		}
	}
}

