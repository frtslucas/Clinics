using Clinics.Application.Abstractions.Interfaces;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Repository;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query.QueryRepository
{
    internal sealed class PaymentQueryRepository : BaseQueryRepository<PaymentQueryModel>, IQueryRepository<PaymentQueryModel>, IPaymentQueryRepository
    {
        public PaymentQueryRepository(QueryDbContext dbContext) : base(dbContext.Payments, dbContext.Payments)
        {
        }
    }
}
