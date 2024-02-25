using System;
using EA.Domain.Core.Abstractions;

namespace EA.Domain.Core.Users
{
	public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}

