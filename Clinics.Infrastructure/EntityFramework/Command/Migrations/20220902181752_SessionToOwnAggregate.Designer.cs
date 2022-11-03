﻿// <auto-generated />
using System;
using Clinics.Infrastructure.EntityFramework.Command;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinics.Infrastructure.EntityFramework.Command.Migrations
{
    [DbContext(typeof(CommandDbContext))]
    [Migration("20220902181752_SessionToOwnAggregate")]
    partial class SessionToOwnAggregate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Clinics")
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Clinics.Domain.Aggregates.PatientAggregate.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Patient", "Clinics");
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.SessionAggregate.Entities.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Payment", "Clinics");
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.SessionAggregate.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Session", "Clinics");
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.PatientAggregate.Patient", b =>
                {
                    b.OwnsOne("Clinics.Domain.Shared.MoneyValue", "AgreedValue", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("AgreedValue");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ExtraLine")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ExtraLine");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("StreetAddress");

                            b1.Property<int?>("StreetNumber")
                                .HasColumnType("int")
                                .HasColumnName("StreetNumber");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");

                            b1.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.City", "City", b2 =>
                                {
                                    b2.Property<Guid>("AddressPatientId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("CityName")
                                        .IsRequired()
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("City");

                                    b2.Property<string>("State")
                                        .HasColumnType("nvarchar(max)")
                                        .HasColumnName("State");

                                    b2.HasKey("AddressPatientId");

                                    b2.ToTable("Patient", "Clinics");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressPatientId");
                                });

                            b1.Navigation("City")
                                .IsRequired();
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.Age", "Age", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("BirthDate");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.CPF", "CPF", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CPF");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Name");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.Occupation", "Occupation", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Occupation");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.PlaceOfBirth", "PlaceOfBirth", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("CountryOfBirth");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.OwnsOne("Clinics.Domain.Aggregates.PatientAggregate.ValueObjects.RG", "RG", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("RG");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patient", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Age")
                        .IsRequired();

                    b.Navigation("AgreedValue")
                        .IsRequired();

                    b.Navigation("CPF")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Occupation")
                        .IsRequired();

                    b.Navigation("PlaceOfBirth")
                        .IsRequired();

                    b.Navigation("RG")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.SessionAggregate.Entities.Payment", b =>
                {
                    b.HasOne("Clinics.Domain.Aggregates.SessionAggregate.Session", null)
                        .WithMany("Payments")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Clinics.Domain.Shared.MoneyValue", "MoneyValue", b1 =>
                        {
                            b1.Property<Guid>("PaymentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Value");

                            b1.HasKey("PaymentId");

                            b1.ToTable("Payment", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("PaymentId");
                        });

                    b.Navigation("MoneyValue")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.SessionAggregate.Session", b =>
                {
                    b.HasOne("Clinics.Domain.Aggregates.PatientAggregate.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Clinics.Domain.Shared.MoneyValue", "MoneyValue", b1 =>
                        {
                            b1.Property<Guid>("SessionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Value");

                            b1.HasKey("SessionId");

                            b1.ToTable("Session", "Clinics");

                            b1.WithOwner()
                                .HasForeignKey("SessionId");
                        });

                    b.Navigation("MoneyValue")
                        .IsRequired();
                });

            modelBuilder.Entity("Clinics.Domain.Aggregates.SessionAggregate.Session", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
