namespace EA.Domain.Core.Abstractions
{
    public abstract class Entity
	{
		private readonly List<IDomainEvent> _events = new();

		public Entity(Guid id)=>Id = id;

		public Guid Id { get; init; }
		public IList<IDomainEvent> DomainEvents => _events.ToList();

		protected void Raise(IDomainEvent domainEvent)
		{
			_events.Add(domainEvent);
		}
	}
}

