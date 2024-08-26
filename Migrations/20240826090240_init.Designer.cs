﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResturangSystem.Data;

#nullable disable

namespace ResturangSystem.Migrations
{
    [DbContext(typeof(ResturangContext))]
    [Migration("20240826090240_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ResturangSystem.Models.Bokning", b =>
                {
                    b.Property<int>("BokningId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BokningId"));

                    b.Property<int>("Antal")
                        .HasColumnType("int");

                    b.Property<int>("BordId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KundId")
                        .HasColumnType("int");

                    b.HasKey("BokningId");

                    b.HasIndex("BordId");

                    b.HasIndex("KundId");

                    b.ToTable("Bokning");

                    b.HasData(
                        new
                        {
                            BokningId = 1,
                            Antal = 2,
                            BordId = 1,
                            Datum = new DateTime(2024, 8, 27, 11, 2, 39, 648, DateTimeKind.Local).AddTicks(2555),
                            KundId = 1
                        },
                        new
                        {
                            BokningId = 2,
                            Antal = 4,
                            BordId = 3,
                            Datum = new DateTime(2024, 8, 28, 11, 2, 39, 648, DateTimeKind.Local).AddTicks(2595),
                            KundId = 2
                        });
                });

            modelBuilder.Entity("ResturangSystem.Models.Bord", b =>
                {
                    b.Property<int>("BordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BordId"));

                    b.Property<bool>("BoolBokad")
                        .HasColumnType("bit");

                    b.Property<int>("Bordsnummer")
                        .HasColumnType("int");

                    b.Property<int>("Platser")
                        .HasColumnType("int");

                    b.Property<int>("RestaurangId")
                        .HasColumnType("int");

                    b.HasKey("BordId");

                    b.HasIndex("RestaurangId");

                    b.ToTable("Bord");

                    b.HasData(
                        new
                        {
                            BordId = 1,
                            BoolBokad = false,
                            Bordsnummer = 101,
                            Platser = 4,
                            RestaurangId = 1
                        },
                        new
                        {
                            BordId = 2,
                            BoolBokad = false,
                            Bordsnummer = 102,
                            Platser = 2,
                            RestaurangId = 1
                        },
                        new
                        {
                            BordId = 3,
                            BoolBokad = false,
                            Bordsnummer = 201,
                            Platser = 4,
                            RestaurangId = 2
                        });
                });

            modelBuilder.Entity("ResturangSystem.Models.Kund", b =>
                {
                    b.Property<int>("KundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KundId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KundId");

                    b.ToTable("Kund");

                    b.HasData(
                        new
                        {
                            KundId = 1,
                            Email = "kunda@example.com",
                            Namn = "Kund A"
                        },
                        new
                        {
                            KundId = 2,
                            Email = "kundb@example.com",
                            Namn = "Kund B"
                        });
                });

            modelBuilder.Entity("ResturangSystem.Models.Meny", b =>
                {
                    b.Property<int>("MenyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenyId"));

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pris")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RestaurangId")
                        .HasColumnType("int");

                    b.Property<bool>("Tillgänglig")
                        .HasColumnType("bit");

                    b.HasKey("MenyId");

                    b.HasIndex("RestaurangId");

                    b.ToTable("Meny");

                    b.HasData(
                        new
                        {
                            MenyId = 1,
                            Namn = "Rätt A",
                            Pris = 100m,
                            RestaurangId = 1,
                            Tillgänglig = true
                        },
                        new
                        {
                            MenyId = 2,
                            Namn = "Rätt B",
                            Pris = 150m,
                            RestaurangId = 1,
                            Tillgänglig = false
                        },
                        new
                        {
                            MenyId = 3,
                            Namn = "Rätt C",
                            Pris = 120m,
                            RestaurangId = 2,
                            Tillgänglig = true
                        });
                });

            modelBuilder.Entity("ResturangSystem.Models.Restaurang", b =>
                {
                    b.Property<int>("RestaurangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurangId"));

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurangId");

                    b.ToTable("Restaurang");

                    b.HasData(
                        new
                        {
                            RestaurangId = 1,
                            Namn = "Restaurang A"
                        },
                        new
                        {
                            RestaurangId = 2,
                            Namn = "Restaurang B"
                        });
                });

            modelBuilder.Entity("ResturangSystem.Models.Bokning", b =>
                {
                    b.HasOne("ResturangSystem.Models.Bord", "Bord")
                        .WithMany("Bokningar")
                        .HasForeignKey("BordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResturangSystem.Models.Kund", "Kund")
                        .WithMany("Bokningar")
                        .HasForeignKey("KundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bord");

                    b.Navigation("Kund");
                });

            modelBuilder.Entity("ResturangSystem.Models.Bord", b =>
                {
                    b.HasOne("ResturangSystem.Models.Restaurang", "Restaurang")
                        .WithMany("Bord")
                        .HasForeignKey("RestaurangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurang");
                });

            modelBuilder.Entity("ResturangSystem.Models.Meny", b =>
                {
                    b.HasOne("ResturangSystem.Models.Restaurang", "Restaurang")
                        .WithMany("Meny")
                        .HasForeignKey("RestaurangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurang");
                });

            modelBuilder.Entity("ResturangSystem.Models.Bord", b =>
                {
                    b.Navigation("Bokningar");
                });

            modelBuilder.Entity("ResturangSystem.Models.Kund", b =>
                {
                    b.Navigation("Bokningar");
                });

            modelBuilder.Entity("ResturangSystem.Models.Restaurang", b =>
                {
                    b.Navigation("Bord");

                    b.Navigation("Meny");
                });
#pragma warning restore 612, 618
        }
    }
}
