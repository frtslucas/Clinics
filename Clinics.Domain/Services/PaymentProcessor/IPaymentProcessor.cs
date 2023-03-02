using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;

namespace Clinics.Domain.Services.PaymentProcessor
{
    public interface IPaymentProcessor : IDomainService
    {
        Task<AssignPaymentToSessionsResult> AssignPaymentToSessionsAsync(Payment payment);
    }
}
