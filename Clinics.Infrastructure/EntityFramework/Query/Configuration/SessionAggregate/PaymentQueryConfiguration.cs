using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.SessionAggregate
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
