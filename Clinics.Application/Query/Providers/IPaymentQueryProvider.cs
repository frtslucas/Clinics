using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PaymentAggregate;

namespace Clinics.Application.Query.Providers
{
    public interface IPaymentQueryProvider : IQueryProvider<PaymentQueryModel>
    {
    }
}
