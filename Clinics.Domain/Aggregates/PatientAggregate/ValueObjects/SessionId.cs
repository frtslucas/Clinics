using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record SessionId : GuidIdentifier, IIdentifier<Guid>
    {
        public SessionId() : base()
        {
        }

        public SessionId(Guid id) : base(id)
        {
        }

        public static SessionId FromGuid(Guid id) => new(id);
    }
}
