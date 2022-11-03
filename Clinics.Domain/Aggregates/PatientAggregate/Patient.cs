using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.Events;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Exceptions;
using Clinics.Domain.Shared;

namespace Clinics.Domain.Aggregates.PatientAggregate
{
    public class Patient : AggregateRoot<PatientId>, IAggregateRoot<PatientId>
    {
        public Name Name { get; private set; }
        public Age Age { get; private set; }
        public Occupation Occupation { get; private set; }
        public PlaceOfBirth? PlaceOfBirth { get; private set; }
        public Address? Address { get; private set; }
        public RG? RG { get; private set; }
        public CPF? CPF { get; private set; }
        public MoneyValue AgreedValue { get; private set; }
        public byte EstimatedMonthSessions { get; private set; }
        public bool Active { get; private set; } = true;

        public Patient(
            PatientId id,
            Name name,
            Age age,
            Occupation occupation,
            PlaceOfBirth? placeOfBirth,
            Address? address,
            RG? rG,
            CPF? cPF,
            MoneyValue agreedValue,
            byte estimatedMonthSessions) : base(id)
        {
            Name = name;
            Age = age;
            Occupation = occupation;
            
            PlaceOfBirth = placeOfBirth;
            Address = address;
            RG = rG;
            CPF = cPF;

            AgreedValue = agreedValue;
            EstimatedMonthSessions = estimatedMonthSessions;

            AddDomainEvent(new PatientCreatedDomainEvent(this));
        }

        public void SetAgreedValue(MoneyValue value)
        {
            if (!Active)
                throw new InactivePacientException();

            AgreedValue = value;
            AddDomainEvent(new AgreedValueSetDomainEvent(Id, AgreedValue));
        }

        public void SetEstimatedMonthSessions(byte estimatedMonthSessions)
        {
            if (!Active)
                throw new InactivePacientException();

            EstimatedMonthSessions = estimatedMonthSessions;
            AddDomainEvent(new EstimatedMonthSessionsSetDomainEvent(Id, EstimatedMonthSessions));
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

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Patient() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
