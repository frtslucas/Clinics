using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.SessionAggregate
{
    internal sealed class SessionPaymentQueryConfiguration : IEntityTypeConfiguration<SessionPaymentQueryModel>
    {
        public void Configure(EntityTypeBuilder<SessionPaymentQueryModel> builder)
        {
            builder.ToTable(nameof(SessionPayment));

            builder.HasKey(p => p.Id);
        }
    }
}
