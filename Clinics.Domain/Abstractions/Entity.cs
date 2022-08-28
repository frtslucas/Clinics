using Clinics.Domain.Abstractions.Interfaces;

namespace Clinics.Domain.Abstractions
{
    public abstract class Entity<TIdentifier> : Entity<TIdentifier, Guid>, IEntity<TIdentifier, Guid>
        where TIdentifier : IIdentifier<Guid>, new()
    {
        protected Entity() : base()
        {

        }

        protected Entity(TIdentifier id) : base(id)
        {
        }
    }

    public abstract class Entity<TIdentifier, TIdType> : IEntity<TIdentifier, TIdType>
        where TIdentifier : IIdentifier<TIdType>, new()
    {
        public TIdentifier Id { get; }

        protected Entity()
        {
            Id = new();
        }

        protected Entity(TIdentifier id)
        {
            Id = id;
        }
    }
}
