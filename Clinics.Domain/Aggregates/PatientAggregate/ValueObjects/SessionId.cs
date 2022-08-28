using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.ValueObjects
{
    public record SessionId : GuidIdentifier, IIdentifier<Guid>
    {
    }
}
