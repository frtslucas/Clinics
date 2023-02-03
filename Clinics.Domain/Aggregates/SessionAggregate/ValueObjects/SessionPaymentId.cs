using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;

namespace Clinics.Domain.Aggregates.SessionAggregate.ValueObjects
{
    public record SessionPaymentId : GuidIdentifier, IIdentifier<Guid>
    {
        public SessionPaymentId() : base()
        {
        }

        public SessionPaymentId(Guid id) : base(id)
        {
        }

        public static SessionPaymentId FromGuid(Guid id) => new(id);
    }
}
