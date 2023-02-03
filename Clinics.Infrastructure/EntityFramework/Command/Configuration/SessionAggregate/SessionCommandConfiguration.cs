using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.ValueObjects;
using Clinics.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Command.Configuration.SessionAggregate
{
    internal sealed class SessionCommandConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(nameof(Session));

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasConversion(id => id.Value, guid => SessionId.FromGuid(guid));

            builder.OwnsOne(s => s.MoneyValue, mv =>
            {
                mv.Property(mv => mv.Value).HasColumnName(nameof(MoneyValue.Value)).HasPrecision(18, 2);
            });

            builder.HasOne<Patient>()
                .WithMany()
                .HasForeignKey(a => a.PatientId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Payments)
                .WithOne()
                .HasForeignKey("SessionId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
