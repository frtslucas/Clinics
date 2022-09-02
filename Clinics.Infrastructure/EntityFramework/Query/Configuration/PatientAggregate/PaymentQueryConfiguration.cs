using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.PatientAggregate
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
