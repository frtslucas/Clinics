using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Abstractions.ValueObjects;
using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Clinics.Domain.Aggregates.PatientAggregate.Events;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate
{
    public class Patient : AggregateRoot<PatientId>, IAggregateRoot<PatientId>
    {
        public Name Name { get; private set; }
        public Age Age { get; private set; }
        public Occupation Occupation { get; private set; }
        public PlaceOfBirth PlaceOfBirth { get; private set; }
        public MoneyValue AgreedValue { get; private set; }
        public Address? Address { get; private set; }
        public RG? RG { get; private set; }
        public CPF? CPF { get; private set; }
        public bool Active { get; private set; } = true;

        private readonly List<Session> _sessions = new();
        public IReadOnlyList<Session> Sessions => _sessions.AsReadOnly();

        public Patient(
            Name name,
            Age age,
            Occupation occupation,
            PlaceOfBirth placeOfBirth,
            MoneyValue agreedValue,
            Address? address = null,
            RG? rG = null,
            CPF? cPF = null)
        {
            Name = name;
            Age = age;
            Occupation = occupation;
            PlaceOfBirth = placeOfBirth;
            AgreedValue = agreedValue;

            Address = address;
            RG = rG;
            CPF = cPF;
        }

        public void AddSession(DateTime date, string? observations)
        {
            if (!Active)
                throw new InactivePacientException();

            var session = new Session(AgreedValue, date, observations);

            _sessions.Add(session);

            AddDomainEvent(new SessionAddedDomainEvent(Id, session.Id));
        }

        public void MarkSessionAsDone(SessionId sessionId, Payment? payment = null)
        {
            if (!Active)
                throw new InactivePacientException();

            var session = _sessions.SingleOrDefault(a => a.Id == sessionId);
            
            if (session is null)
                throw new InvalidSessionIdForPacientException();

            session.MarkAsDone();
            AddDomainEvent(new SessionDoneDomainEvent(Id, session.Id));

            if (payment is not null)
                AddPaymentToSession(sessionId, payment);
        }

        public void AddPaymentToSession(SessionId sessionId, Payment payment)
        {
            if (!Active)
                throw new InactivePacientException();

            var session = _sessions.SingleOrDefault(a => a.Id == sessionId);

            if (session is null)
                throw new InvalidSessionIdForPacientException();

            session.AddPayment(payment);
            AddDomainEvent(new PaymentAddedToSessionDomainEvent(session.Id, payment.Id));

            if (session.Paid)
                AddDomainEvent(new SessionPaidDomainEvent(session.Id));
        }

        public void Inactivate()
        {
            Active = false;

            AddDomainEvent(new PatientInactivatedDomainEvent(Id));
        }

        public void Reactivate()
        {
            Active = true;

            AddDomainEvent(new PatientReactivatedDomainEvent(Id));
        }
    }
}
