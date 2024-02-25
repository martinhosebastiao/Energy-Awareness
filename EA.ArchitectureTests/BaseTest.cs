using EA.Application.Core.Abstractions;
using EA.Domain.Core.Abstractions;
using System.Reflection;

namespace EA.ArchitectureTests
{
    public abstract class BaseTest
	{
        
        protected static readonly Assembly DomainAssemblyReference = typeof(Entity).Assembly;
        protected static readonly Assembly ApplicationAssemblyReference = typeof(BaseApp).Assembly;
        protected static readonly Assembly InfrastructureAssemblyReference = typeof(BaseApp).Assembly;
        protected static readonly Assembly PresentationAssemblyReference = typeof(BaseApp).Assembly;

        #region - Layers Namespace -
        protected const string DomainNamespace = "Domain";
        protected const string ApplicationNamespace = "Application";
        protected const string InfrastructureNamespace = "Infrastructure";
        protected const string PresentationNamespace = "Presentation";
        #endregion

    }
}