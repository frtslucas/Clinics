using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate.ValueObjects;

namespace Clinics.Domain.Aggregates.PaymentAggregate
{
    public interface IPaymentRepository : IRepository<Payment, PaymentId>
    {
    }
}
