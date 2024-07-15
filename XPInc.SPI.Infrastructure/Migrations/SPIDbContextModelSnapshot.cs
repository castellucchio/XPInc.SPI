﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using XPInc.SPI.Infrastructure.DbContexts;

#nullable disable

namespace XPInc.SPI.Infrastructure.Migrations
{
    [DbContext(typeof(SPIDbContext))]
    partial class SPIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("XPInc.SPI.Entities.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BranchNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            ClientId = 1,
                            Account = "12345-6",
                            BranchNumber = "7890",
                            Document = "123.456.789-00",
                            Name = "Jhon Doe"
                        },
                        new
                        {
                            ClientId = 2,
                            Account = "98765-4",
                            BranchNumber = "4321",
                            Document = "987.654.321-00",
                            Name = "Jane Smith"
                        });
                });

            modelBuilder.Entity("XPInc.SPI.Entities.Models.FinantialProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FinantialProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Descrição do Produto A",
                            ExpireDate = new DateTime(2024, 8, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2804),
                            Name = "Produto financeiro A",
                            Price = 100.0m,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Descrição do Produto B",
                            ExpireDate = new DateTime(2024, 9, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2819),
                            Name = "Produto financeiro B",
                            Price = 250.0m,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Descrição do Produto C",
                            ExpireDate = new DateTime(2024, 10, 15, 19, 15, 57, 637, DateTimeKind.Local).AddTicks(2821),
                            Name = "Produto financeiro C",
                            Price = 450.0m,
                            Type = 3
                        });
                });

            modelBuilder.Entity("XPInc.SPI.Entities.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinantialProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FinantialProductId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("XPInc.SPI.Entities.Models.Transaction", b =>
                {
                    b.HasOne("XPInc.SPI.Entities.Models.Client", "Client")
                        .WithMany("Transactions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("XPInc.SPI.Entities.Models.FinantialProduct", "FinancialProduct")
                        .WithMany()
                        .HasForeignKey("FinantialProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("FinancialProduct");
                });

            modelBuilder.Entity("XPInc.SPI.Entities.Models.Client", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
