using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Clinics.Domain.Exceptions;

namespace Clinics.Domain.Aggregates.PatientAggregate.Entities
{
    public class Session : Entity<SessionId>, IEntity<SessionId>
    {
        public MoneyValue MoneyValue { get; private set; }
        public DateTime Date { get; set; }
        public string? Observations { get; private set; }
        public bool Done { get; private set; }
        public bool Paid { get => _payments.Sum(a => a.MoneyValue.Value) == MoneyValue.Value; }

        private readonly List<Payment> _payments = new();
        public IReadOnlyList<Payment> Payments => _payments.AsReadOnly();

        public Session(MoneyValue moneyValue, DateTime date, string? observations)
        {
            MoneyValue = moneyValue;
            Date = date;
            Observations = observations;
        }

        public void MarkAsDone()
        {
            Done = true;
        }

        public void AddPayment(Payment payment)
        {
            if (_payments.Sum(a => a.MoneyValue.Value) + payment.MoneyValue.Value > MoneyValue.Value)
                throw new InvalidPaymentException();

            _payments.Add(payment);
        }
    }
}
