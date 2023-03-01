using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate.ValueObjects;
using Clinics.Domain.Shared;
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

            builder.OwnsOne(p => p.Value, mv =>
            {
                mv.Property(mv => mv.Ammount).HasColumnName(nameof(Value)).HasPrecision(18, 2);
            });

            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}