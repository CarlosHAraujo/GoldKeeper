﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20181102194303_AddCosts")]
    partial class AddCosts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Domain.Cost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Costs");
                });

            modelBuilder.Entity("Domain.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("Discount");

                    b.Property<decimal>("GrandTotal");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Domain.ExtraCost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CostId");

                    b.Property<int?>("ExpenseId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CostId");

                    b.HasIndex("ExpenseId");

                    b.ToTable("ExtraCost");
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExpenseId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExpenseId");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Domain.Expense", b =>
                {
                    b.HasOne("Domain.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("Domain.ExtraCost", b =>
                {
                    b.HasOne("Domain.Cost", "Cost")
                        .WithMany()
                        .HasForeignKey("CostId");

                    b.HasOne("Domain.Expense")
                        .WithMany("ExtraCosts")
                        .HasForeignKey("ExpenseId");
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.HasOne("Domain.Expense")
                        .WithMany("PaymentMethod")
                        .HasForeignKey("ExpenseId");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.HasOne("Domain.Expense")
                        .WithMany("Products")
                        .HasForeignKey("ExpenseId");
                });
#pragma warning restore 612, 618
        }
    }
}
