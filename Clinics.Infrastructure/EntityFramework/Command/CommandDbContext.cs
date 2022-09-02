using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Infrastructure.EntityFramework.Command.Configuration.PatientAggregate;
using Microsoft.EntityFrameworkCore;

namespace Clinics.Infrastructure.EntityFramework.Command
{
    internal sealed class CommandDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } = null!;

        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Constants.DEFAULTDBSCHEMA);

            modelBuilder.ApplyConfiguration(new PatientCommandConfiguration());
            modelBuilder.ApplyConfiguration(new SessionCommandConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentCommandConfiguration());
        }
    }
}
