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

        public Value Value { get; private set; }
        public DateTime Date { get; set; }
        public string? Observations { get; private set; }
        public bool Done { get; private set; }
        public bool Paid { get; private set; }
        public Value UnpaidValue { get => Value - Value.FromDecimal(_payments.Sum(a => a.Value.Ammount)); }

        private readonly List<SessionPayment> _payments = new();
        public IReadOnlyList<SessionPayment> Payments => _payments.AsReadOnly();

        public Session(Patient patient, DateTime date, string? observations) 
            : base()
        {
            if (!patient.Active)
                throw new InactivePacientException();

            if (patient.AgreedValue is null)
                throw new AgreedValueNotSetException(patient.Name);

            PatientId = patient.Id;
            Value = patient.AgreedValue;
            Date = date;
            Observations = observations;

            AddDomainEvent(new SessionCreatedDomainEvent(this));
        }

        public void MarkAsDone()
        {
            Done = true;

            AddDomainEvent(new SessionDoneDomainEvent(PatientId, Id));
        }

        public void AddPayment(Value value, DateTime dateTime)
        {
            var sessionPayment = new SessionPayment(value, dateTime);
            AddPayment(sessionPayment);
        }

        public void AddPayment(SessionPayment payment)
        {
            if (_payments.Sum(a => a.Value.Ammount) + payment.Value.Ammount > Value.Ammount)
                throw new InvalidPaymentException();

            _payments.Add(payment);

            AddDomainEvent(new SessionPaymentAddedToSessionDomainEvent(Id, payment.Id));

            Paid = _payments.Sum(a => a.Value.Ammount) == Value.Ammount;

            if (Paid)
                AddDomainEvent(new SessionPaidDomainEvent(Id));
        }

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Session() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
