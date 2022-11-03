using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Query.Configuration.SessionAggregate
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
