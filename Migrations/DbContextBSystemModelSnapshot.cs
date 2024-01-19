﻿// <auto-generated />
using BankingProyect.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BankingProyect.Migrations
{
    [DbContext(typeof(DbContextBSystem))]
    partial class DbContextBSystemModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankingProyect.Entities.Accounts", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .IsRequired();

                    b.Property<decimal>("Balance");

                    b.Property<int?>("JournalIdJournal");

                    b.HasKey("IdAccount");

                    b.HasIndex("JournalIdJournal");

                    b.ToTable("Acounts");
                });

            modelBuilder.Entity("BankingProyect.Entities.Commisions", b =>
                {
                    b.Property<int>("IdCommision")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Commision");

                    b.Property<int?>("OperationsIdOperation");

                    b.HasKey("IdCommision");

                    b.HasIndex("OperationsIdOperation");

                    b.ToTable("Commisions");
                });

            modelBuilder.Entity("BankingProyect.Entities.Currencys", b =>
                {
                    b.Property<int>("IdCurrency")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.Property<int?>("JournalIdJournal");

                    b.HasKey("IdCurrency");

                    b.HasIndex("JournalIdJournal");

                    b.ToTable("Currencys");
                });

            modelBuilder.Entity("BankingProyect.Entities.Journal", b =>
                {
                    b.Property<int>("IdJournal")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<DateTime>("DateAmount");

                    b.Property<float>("TotalCommision");

                    b.HasKey("IdJournal");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("BankingProyect.Entities.Operations", b =>
                {
                    b.Property<int>("IdOperation")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("JournalIdJournal");

                    b.Property<string>("Operation");

                    b.HasKey("IdOperation");

                    b.HasIndex("JournalIdJournal");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("BankingProyect.Entities.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccountsIdAccount");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("IdUser");

                    b.HasIndex("AccountsIdAccount");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankingProyect.Entities.Accounts", b =>
                {
                    b.HasOne("BankingProyect.Entities.Journal")
                        .WithMany("IdAcount")
                        .HasForeignKey("JournalIdJournal");
                });

            modelBuilder.Entity("BankingProyect.Entities.Commisions", b =>
                {
                    b.HasOne("BankingProyect.Entities.Operations")
                        .WithMany("IdCommision")
                        .HasForeignKey("OperationsIdOperation");
                });

            modelBuilder.Entity("BankingProyect.Entities.Currencys", b =>
                {
                    b.HasOne("BankingProyect.Entities.Journal")
                        .WithMany("IdCurrency")
                        .HasForeignKey("JournalIdJournal");
                });

            modelBuilder.Entity("BankingProyect.Entities.Operations", b =>
                {
                    b.HasOne("BankingProyect.Entities.Journal")
                        .WithMany("IdOperation")
                        .HasForeignKey("JournalIdJournal");
                });

            modelBuilder.Entity("BankingProyect.Entities.Users", b =>
                {
                    b.HasOne("BankingProyect.Entities.Accounts")
                        .WithMany("IdUser")
                        .HasForeignKey("AccountsIdAccount");
                });
#pragma warning restore 612, 618
        }
    }
}