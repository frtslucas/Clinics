using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PaymentAggregate;

namespace Clinics.Application.Query.Repository
{
    public interface IPaymentQueryRepository : IQueryRepository<PaymentQueryModel>
    {
    }
}
