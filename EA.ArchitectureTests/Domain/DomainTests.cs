using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using EA.Domain.Core.Abstractions;
namespace EA.ArchitectureTests.Domain
{
    public class DomainTests : BaseTest
    {
        [Fact(DisplayName = "Eventos de Dominio devem ser Selados")]
        public void DomainEvents_Should_BeSealed()
        {
            // Garante que as implementações da interface IDomainEvent sejam Sealed
            var result = Types.InAssembly(DomainAssemblyReference)
                              .That()
                              .ImplementInterface(typeof(IDomainEvent))
                              .Should()
                              .BeSealed()
                              .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Eventos de Dominio devem ter o sufixo DomainEvent")]
        public void DomainEvents_Should_HaveDomainEventPostfix()
        {
            var result = Types.InAssembly(DomainAssemblyReference)
                              .That()
                              .ImplementInterface(typeof(IDomainEvent))
                              .Should()
                              .HaveNameEndingWith("DomainEvent")
                              .GetResult();

            result.IsSuccessful.Should().BeTrue();
        }

        [Fact(DisplayName = "Entidades devem ter parametros privados menos o construtor")]
        public void Entities_Should_HavePrivateParameterLessConstructor()
        {
            List<Type> failingTypes = new();

            var entityTypes = Types.InAssembly(DomainAssemblyReference)
                                   .That()
                                   .Inherit(typeof(Entity))
                                   .GetTypes();

            foreach (var type in entityTypes)
            {
                var constructors = type.GetConstructors(BindingFlags.NonPublic |
                                                        BindingFlags.Instance);

                var isValid = constructors.Any(c => c.IsPrivate &&
                                                    c.GetParameters()
                                                     .Length == 0);
                if (isValid)
                    failingTypes.Add(type);
            }

            failingTypes.Should().BeEmpty();
        }
    }
}

