﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Techbuzzers_bank.Data;

#nullable disable

namespace Techbuzzers_bank.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240501104157_t1")]
    partial class t1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Techbuzzers_bank.Models.Account", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("balance")
                        .HasColumnType("real");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("account");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.Loans", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("accountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<float>("due")
                        .HasColumnType("real");

                    b.Property<int>("roi")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("tenure")
                        .HasColumnType("int");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("loans");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.Payables", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Loansid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<string>("loanId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("month")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Loansid");

                    b.ToTable("Payables");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.Transactions", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("amount")
                        .HasColumnType("real");

                    b.Property<int>("creditId")
                        .HasColumnType("int");

                    b.Property<int>("debitId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.UserDetails", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("accountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("phoneNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("pin")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("userDetails");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.Payables", b =>
                {
                    b.HasOne("Techbuzzers_bank.Models.Loans", null)
                        .WithMany("payables")
                        .HasForeignKey("Loansid");
                });

            modelBuilder.Entity("Techbuzzers_bank.Models.Loans", b =>
                {
                    b.Navigation("payables");
                });
#pragma warning restore 612, 618
        }
    }
}