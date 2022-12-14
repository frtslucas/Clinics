using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Clinics.Domain.Aggregates.SessionAggregate.Events;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Exceptions;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.SessionAggregate
{
    public class Session : AggregateRoot<SessionId>, IAggregateRoot<SessionId>
    {
        public PatientId PatientId { get; init; }

        public MoneyValue MoneyValue { get; private set; }
        public DateTime Date { get; set; }
        public string? Observations { get; private set; }
        public bool Done { get; private set; }
        public bool Paid { get; private set; }

        private readonly List<Payment> _payments = new();
        public IReadOnlyList<Payment> Payments => _payments.AsReadOnly();

        private Session(SessionId id, PatientId patientId, MoneyValue moneyValue, DateTime date, string? observations) : base(id)
        {
            PatientId = patientId;
            MoneyValue = moneyValue;
            Date = date;
            Observations = observations;

            AddDomainEvent(new SessionCreatedDomainEvent(this));
        }

        public void MarkAsDone(Payment? payment = null)
        {
            Done = true;

            if (payment is not null)
                AddPayment(payment);
        }

        public void AddPayment(Payment payment)
        {
            if (_payments.Sum(a => a.MoneyValue.Value) + payment.MoneyValue.Value > MoneyValue.Value)
                throw new InvalidPaymentException();

            _payments.Add(payment);

            Paid = _payments.Sum(a => a.MoneyValue.Value) == MoneyValue.Value;

            AddDomainEvent(new PaymentAddedToSessionDomainEvent(Id, payment.Id));

            if (Paid)
                AddDomainEvent(new SessionPaidDomainEvent(Id));
        }

        public static Session NewSession(SessionId sessionId, Patient patient, DateTime date, string? observations)
        {
            if (!patient.Active)
                throw new InactivePacientException();

            if (patient.AgreedValue is null)
                throw new AgreedValueNotSetException(patient.Name);

            return new(sessionId, patient.Id, patient.AgreedValue, date, observations);
        }

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Session() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
