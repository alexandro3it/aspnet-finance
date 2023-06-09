﻿// <auto-generated />
using System;
using ASPFinance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPFinance.Migrations
{
    [DbContext(typeof(FinanceContext))]
    [Migration("20230322224713_AddInitialCreate")]
    partial class AddInitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ASPFinance.Model.Data.Credit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreditDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripton")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Credits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreditDay = new DateTime(2023, 3, 22, 18, 22, 13, 722, DateTimeKind.Local).AddTicks(1451),
                            CustomerId = 1,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1450),
                            Descripton = "Samsung modelo S1",
                            Title = "Samsung S1",
                            Value = 5000.99m
                        },
                        new
                        {
                            Id = 2,
                            CreditDay = new DateTime(2023, 3, 22, 18, 27, 13, 722, DateTimeKind.Local).AddTicks(1453),
                            CustomerId = 1,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1452),
                            Descripton = "Motolora modelo M1",
                            Title = "Motolora M1",
                            Value = 4000.99m
                        },
                        new
                        {
                            Id = 3,
                            CreditDay = new DateTime(2023, 3, 22, 18, 32, 13, 722, DateTimeKind.Local).AddTicks(1455),
                            CustomerId = 2,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1454),
                            Descripton = "LG modelo LG1",
                            Title = "LG LG1",
                            Value = 3000.99m
                        },
                        new
                        {
                            Id = 4,
                            CreditDay = new DateTime(2023, 3, 22, 18, 32, 13, 722, DateTimeKind.Local).AddTicks(1456),
                            CustomerId = 2,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1456),
                            Descripton = "Motolora modelo M2",
                            Title = "Motolora M2",
                            Value = 3509.99m
                        });
                });

            modelBuilder.Entity("ASPFinance.Model.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cliente 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cliente 2"
                        });
                });

            modelBuilder.Entity("ASPFinance.Model.Data.Debit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DebtDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripton")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Debits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1415),
                            DebtDay = new DateTime(2023, 3, 22, 18, 17, 13, 722, DateTimeKind.Local).AddTicks(1425),
                            Descripton = "Campanhia de Distribuição de Energia",
                            SupplierId = 1,
                            Title = "Energia",
                            Value = 500.99m
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1433),
                            DebtDay = new DateTime(2023, 3, 22, 18, 32, 13, 722, DateTimeKind.Local).AddTicks(1434),
                            Descripton = "Campanhia de Tratamento de Agua e esgoto",
                            SupplierId = 2,
                            Title = "Água e esgoto",
                            Value = 400.99m
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1435),
                            DebtDay = new DateTime(2023, 3, 22, 18, 37, 13, 722, DateTimeKind.Local).AddTicks(1436),
                            Descripton = "Campanhia de Comunicações",
                            SupplierId = 3,
                            Title = "Internet",
                            Value = 300.99m
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2023, 3, 22, 19, 47, 13, 722, DateTimeKind.Local).AddTicks(1437),
                            DebtDay = new DateTime(2023, 3, 22, 18, 42, 13, 722, DateTimeKind.Local).AddTicks(1438),
                            Descripton = "Campanhia de Comunicações",
                            SupplierId = 3,
                            Title = "Telefone",
                            Value = 350.99m
                        });
                });

            modelBuilder.Entity("ASPFinance.Model.Data.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Forncedor 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Forncedor 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Forncedor 2"
                        });
                });

            modelBuilder.Entity("ASPFinance.Model.Data.Credit", b =>
                {
                    b.HasOne("ASPFinance.Model.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ASPFinance.Model.Data.Debit", b =>
                {
                    b.HasOne("ASPFinance.Model.Data.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });
#pragma warning restore 612, 618
        }
    }
}
