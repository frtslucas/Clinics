using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Command.Configuration.PatientAggregate
{
    internal sealed class PaymentCommandConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable(nameof(Payment));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(id => id.Value, guid => PaymentId.FromGuid(guid));

            builder.OwnsOne(p => p.MoneyValue, mv =>
            {
                mv.Property(mv => mv.Value).HasColumnName(nameof(MoneyValue.Value)).HasPrecision(18, 2);
            });
        }
    }
}
