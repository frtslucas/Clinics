using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PaymentAggregate;
using Clinics.Domain.Aggregates.SessionAggregate;
using Clinics.Infrastructure.EntityFramework.Command.Configuration.PatientAggregate;
using Clinics.Infrastructure.EntityFramework.Command.Configuration.SessionAggregate;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Command
{
    internal sealed class CommandDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;

        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DEFAULTDBSCHEMA);

            modelBuilder.ApplyConfiguration(new PatientCommandConfiguration());
            modelBuilder.ApplyConfiguration(new SessionCommandConfiguration());
            modelBuilder.ApplyConfiguration(new SessionPaymentCommandConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentCommandConfiguration());
        }
    }
}
