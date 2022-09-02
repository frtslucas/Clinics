using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record PaymentId : GuidIdentifier, IIdentifier<Guid>
    {
        public PaymentId() : base()
        {
        }

        public PaymentId(Guid id) : base(id)
        {
        }

        public static PaymentId FromGuid(Guid id) => new(id);
    }
}
