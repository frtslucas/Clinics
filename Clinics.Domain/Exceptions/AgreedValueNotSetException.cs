using Clinics.Domain.Abstractions;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Exceptions
{
    internal class AgreedValueNotSetException : CustomException
    {
        public AgreedValueNotSetException(Name patientName) : base($"Agreed value for patient {patientName} is not set yet")
        {
        }
    }
}
