using Clinics.Domain.Abstractions.Interfaces;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate.ValueObjects;

namespace Clinics.Infrastructure.EntityFramework.Command.Repositories
{
    internal sealed class PaymentRepository : BaseRepository<Payment, PaymentId>, IRepository<Payment, PaymentId>, IPaymentRepository
    {
        public PaymentRepository(CommandDbContext dbContext) : base(dbContext.Payments, dbContext.Payments)
        {
        }
    }
}
