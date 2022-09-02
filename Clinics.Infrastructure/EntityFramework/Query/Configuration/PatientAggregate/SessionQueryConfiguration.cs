using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.PatientAggregate
{
    internal sealed class SessionQueryConfiguration : IEntityTypeConfiguration<SessionQueryModel>
    {
        public void Configure(EntityTypeBuilder<SessionQueryModel> builder)
        {
            builder.ToTable(nameof(Session));

            builder.HasKey(s => s.Id);

            builder.HasMany(s => s.Payments)
                .WithOne(p => p.Session);
        }
    }
}
