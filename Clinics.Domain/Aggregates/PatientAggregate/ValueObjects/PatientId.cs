using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record PatientId : GuidIdentifier, IIdentifier
    {
        public PatientId() : base()
        {
        }

        public PatientId(Guid id) : base(id)
        {
        }

        public static PatientId FromGuid(Guid id) => new(id);
    }
}
