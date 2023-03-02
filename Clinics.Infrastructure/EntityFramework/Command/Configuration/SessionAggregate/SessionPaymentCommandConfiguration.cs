using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Command.Configuration.SessionAggregate
{
    internal sealed class SessionPaymentCommandConfiguration : IEntityTypeConfiguration<SessionPayment>
    {
        public void Configure(EntityTypeBuilder<SessionPayment> builder)
        {
            builder.ToTable(nameof(SessionPayment));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(id => id.Value, guid => SessionPaymentId.FromGuid(guid));

            builder.OwnsOne(p => p.Value, mv =>
            {
                mv.Property(mv => mv.Amount).HasColumnName("Value").HasPrecision(18, 2);
            });
        }
    }
}
