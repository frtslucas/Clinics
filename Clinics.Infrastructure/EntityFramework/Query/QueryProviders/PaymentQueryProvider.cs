using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Providers;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryProviders
{
    internal sealed class PaymentQueryProvider : BaseQueryProvider<PaymentQueryModel>, IQueryProvider<PaymentQueryModel>, IPaymentQueryProvider
    {
        public PaymentQueryProvider(QueryDbContext dbContext) : base(dbContext.Payments, dbContext.Payments)
        {
        }
    }
}
