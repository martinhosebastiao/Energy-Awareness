using System;
using FluentAssertions;
using NetArchTest.Rules;

namespace EA.ArchitectureTests
{
    public class LayerTests : BaseTest
    {
        [Fact(DisplayName = "Dominio não deve ter dependencia da Camada de Aplicação")]
        public void Domain_Should_Not_Have_Dependency_On_Application()
        {
            var result = Types.InAssembly(DomainAssemblyReference)
                              .Should()
                              .NotHaveDependencyOn(ApplicationNamespace)
                              .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Dominio não deve ter dependência dos outros projectos")]
        public void Domain_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange
            var otherProjects = new[]
            {
                ApplicationNamespace,
                InfrastructureNamespace,
                PresentationNamespace
            };

            // Act
            var result = Types.InAssembly(DomainAssemblyReference)
                              .ShouldNot()
                              .HaveDependencyOnAll(otherProjects)
                              .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Application não deve ter dependência dos outros projectos")]
        public void Application_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange
            var otherProjects = new[]
            {
                InfrastructureNamespace,
                PresentationNamespace
            };

            // Act
            var result = Types.InAssembly(ApplicationAssemblyReference)
                              .ShouldNot()
                              .HaveDependencyOnAll(otherProjects)
                              .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Infrastructure não deve ter dependência dos outros projectos")]
        public void Infrastructure_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange
            var otherProjects = new[]
            {
                PresentationNamespace
            };

            // Act
            var result = Types.InAssembly(InfrastructureAssemblyReference)
                              .ShouldNot()
                              .HaveDependencyOnAll(otherProjects)
                              .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Presentation não deve ter dependência dos outros projectos")]
        public void Presentation_Should_Not_Have_Dependency_On_Other_Projects()
        {
            // Arrange
            var otherProjects = new[]
            {
                InfrastructureNamespace
            };

            // Act
            var result = Types.InAssembly(PresentationAssemblyReference)
                              .ShouldNot()
                              .HaveDependencyOnAll(otherProjects)
                              .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }
    }
}

