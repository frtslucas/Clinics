using Clinics.Domain.Abstractions;
using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PatientAggregate.Entities
{
    public class Payment : Entity<PaymentId>, IEntity<PaymentId>
    {
        public MoneyValue MoneyValue { get; private set; }
        public DateTime Date { get; private set; }

        public Payment(MoneyValue moneyValue, DateTime date)
        {
            MoneyValue = moneyValue;
            Date = date;
        }

        #region EF
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private Payment() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        #endregion
    }
}
