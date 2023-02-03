using Clinics.Application.Query.Models.PatientAggregate;
using Clinics.Application.Query.Models.PaymentAggregate;
using Clinics.Application.Query.Models.SessionAggregate;
using Clinics.Infrastructure.EntityFramework.Query.Configuration.PatientAggregate;
using Clinics.Infrastructure.EntityFramework.Query.Configuration.PaymentAggregate;
using Clinics.Infrastructure.EntityFramework.Query.Configuration.SessionAggregate;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Query
{
    internal sealed class QueryDbContext : DbContext
    {
        public DbSet<PatientQueryModel> Patients { get; set; } = null!;
        public DbSet<SessionQueryModel> Sessions { get; set; } = null!;
        public DbSet<PaymentQueryModel> Payments { get; set; } = null!;

        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DEFAULTDBSCHEMA);

            modelBuilder.ApplyConfiguration(new PatientQueryConfiguration());
            modelBuilder.ApplyConfiguration(new SessionQueryConfiguration());
            modelBuilder.ApplyConfiguration(new SessionPaymentQueryConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentQueryConfiguration());
        }
    }
}
