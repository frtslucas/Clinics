using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.PatientAggregate
{
    internal sealed class PatientQueryConfiguration : IEntityTypeConfiguration<PatientQueryModel>
    {
        public void Configure(EntityTypeBuilder<PatientQueryModel> builder)
        {
            builder.ToTable(nameof(Patient));

            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Sessions)
                .WithOne(s => s.Patient);

            builder.HasMany(p => p.Payments)
                .WithOne(s => s.Patient);
        }
    }
}
