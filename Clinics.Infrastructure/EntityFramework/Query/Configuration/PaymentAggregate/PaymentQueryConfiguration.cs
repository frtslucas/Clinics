using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.PaymentAggregate
{
    internal sealed class PaymentQueryConfiguration : IEntityTypeConfiguration<PaymentQueryModel>
    {
        public void Configure(EntityTypeBuilder<PaymentQueryModel> builder)
        {
            builder.ToTable(nameof(Payment));

            builder.HasKey(p => p.Id);
        }
    }
}
