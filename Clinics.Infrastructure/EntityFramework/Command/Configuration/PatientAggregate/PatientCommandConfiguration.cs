using Clinics.Domain.Abstractions.ValueObjects;
using Clinics.Domain.Aggregates.PatientAggregate;
using Clinics.Domain.Aggregates.PatientAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinics.Infrastructure.EntityFramework.Command.Configuration.PatientAggregate
{
    internal sealed class PatientCommandConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable(nameof(Patient));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasConversion(id => id.Value, guid => PatientId.FromGuid(guid));

            builder.OwnsOne(p => p.Name, n =>
            {
                n.Property(n => n.Value).HasColumnName(nameof(Patient.Name));
            });

            builder.OwnsOne(p => p.Age, a =>
            {
                a.Property(a => a.BirthDate).HasColumnName(nameof(Age.BirthDate));
            });

            builder.OwnsOne(p => p.Occupation, o =>
            {
                o.Property(o => o.Value).HasColumnName(nameof(Patient.Occupation));
            });

            builder.OwnsOne(p => p.PlaceOfBirth, pb =>
            {
                pb.Property(pb => pb.Country).HasColumnName("CountryOfBirth");
            });

            builder.OwnsOne(p => p.AgreedValue, av =>
            {
                av.Property(av => av.Value)
                    .HasColumnName(nameof(Patient.AgreedValue))
                    .HasPrecision(18, 2);
            });

            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(a => a.StreetAddress).HasColumnName(nameof(Address.StreetAddress));
                a.Property(a => a.StreetNumber).HasColumnName(nameof(Address.StreetNumber));
                a.Property(a => a.ExtraLine).HasColumnName(nameof(Address.ExtraLine));
                a.OwnsOne(a => a.City, c =>
                {
                    c.Property(c => c.CityName).HasColumnName("City");
                    c.Property(c => c.State).HasColumnName(nameof(City.State));
                });
            });

            builder.OwnsOne(p => p.RG, r =>
            {
                r.Property(r => r.Value).HasColumnName(nameof(RG));
            });

            builder.OwnsOne(p => p.CPF, c =>
            {
                c.Property(c => c.Value).HasColumnName(nameof(CPF));
            });

            builder.HasMany(a => a.Sessions)
                .WithOne();
        }
    }
}