﻿// <auto-generated />
using System;
using Hadrian.CodingAssignment.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Hadrian.CodingAssignment.Infrastructure.Migrations
{
    [DbContext(typeof(HadrianDbContext))]
    partial class HadrianDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_organizations");

                    b.ToTable("organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("19161394-fc07-4086-a581-5727cc8bfee8"),
                            Name = "Hadrian"
                        });
                });

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.Risk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id");

                    b.Property<string>("RiskSeverity")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("risk_severity");

                    b.Property<string>("RiskStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("risk_status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("VulnerabilityId")
                        .HasColumnType("text")
                        .HasColumnName("vulnerability_id");

                    b.HasKey("Id")
                        .HasName("pk_risks");

                    b.HasIndex("OrganizationId")
                        .HasDatabaseName("ix_risks_organization_id");

                    b.ToTable("risks", (string)null);

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("2d590ae4-36e9-485e-9bc8-f42a29123f4d"),
                            Created = new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3677), new TimeSpan(0, 0, 0, 0, 0)),
                            OrganizationId = new Guid("19161394-fc07-4086-a581-5727cc8bfee8"),
                            RiskSeverity = "Low",
                            RiskStatus = "New",
                            Title = "Low severity initial risk"
                        },
                        new
                        {
                            Id = new Guid("5de2e659-4b83-4cef-b5f0-b621cf3812de"),
                            Created = new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3683), new TimeSpan(0, 0, 0, 0, 0)),
                            OrganizationId = new Guid("19161394-fc07-4086-a581-5727cc8bfee8"),
                            RiskSeverity = "Medium",
                            RiskStatus = "New",
                            Title = "Medium severity initial risk"
                        },
                        new
                        {
                            Id = new Guid("747b90aa-1013-4f19-9c0a-e567d2ff0c35"),
                            Created = new DateTimeOffset(new DateTime(2024, 10, 4, 13, 26, 34, 47, DateTimeKind.Unspecified).AddTicks(3685), new TimeSpan(0, 0, 0, 0, 0)),
                            OrganizationId = new Guid("19161394-fc07-4086-a581-5727cc8bfee8"),
                            RiskSeverity = "High",
                            RiskStatus = "New",
                            Title = "High severity initial risk"
                        });
                });

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid")
                        .HasColumnName("organization_id");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("OrganizationId")
                        .HasDatabaseName("ix_users_organization_id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("076dc2f8-e6dd-471b-9aa1-36418e5f7f2a"),
                            OrganizationId = new Guid("19161394-fc07-4086-a581-5727cc8bfee8"),
                            PasswordHash = "TAC1U1saMwgrjoG2",
                            Username = "Hadrian"
                        });
                });

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.Risk", b =>
                {
                    b.HasOne("Hadrian.CodingAssignment.Infrastructure.Model.Organization", "Organization")
                        .WithMany("Risks")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_risks_organizations_organization_id");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.User", b =>
                {
                    b.HasOne("Hadrian.CodingAssignment.Infrastructure.Model.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_organizations_organization_id");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Hadrian.CodingAssignment.Infrastructure.Model.Organization", b =>
                {
                    b.Navigation("Risks");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
