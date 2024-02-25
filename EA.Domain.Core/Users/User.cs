using EA.Domain.Core.Abstractions;

namespace EA.Domain.Core.Users
{
    public sealed class User: Entity
	{
		public User(Guid id, Name name): base(id)
		{
			Name = name;
		}

		public Name Name { get; private set; }

		public static User Create(Name name)
		{
			var user = new User(Guid.NewGuid(), name);

			user.Raise(new UserCreatedDomainEvent(user.Id));

			return user;
		}
	}
}

