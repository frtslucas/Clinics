using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.PaymentAggregate.Events;
using Clinics.Domain.Aggregates.PaymentAggregate.ValueObjects;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.PaymentAggregate
{
    public class Payment : AggregateRoot<PaymentId>, IAggregateRoot<PaymentId>
    {
        public PatientId PatientId { get; init; }

        public MoneyValue MoneyValue { get; private set; }
        public DateTime Date { get; private set; }

        public Payment(PatientId patientId, MoneyValue moneyValue, DateTime date)
        {
            PatientId = patientId;
            MoneyValue = moneyValue;
            Date = date;

            AddDomainEvent(new PaymentCreatedDomainEvent(this));
        }

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Payment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
