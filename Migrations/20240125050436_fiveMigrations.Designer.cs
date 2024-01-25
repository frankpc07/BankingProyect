﻿// <auto-generated />
using BankingProyect.Data;
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
    [Migration("20240125050436_fiveMigrations")]
    partial class fiveMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BankingProyect.Models.Entity.Accounts", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .IsRequired();

                    b.Property<decimal>("Balance");

                    b.Property<int>("IdClient");

                    b.HasKey("IdAccount");

                    b.HasIndex("IdClient");

                    b.ToTable("Acounts");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Clients", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<int>("IdUser");

                    b.Property<string>("LastName");

                    b.HasKey("IdClient");

                    b.HasIndex("IdUser");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Commisions", b =>
                {
                    b.Property<int>("IdCommision")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Commision");

                    b.HasKey("IdCommision");

                    b.ToTable("Commisions");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Currencys", b =>
                {
                    b.Property<int>("IdCurrency")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Currency");

                    b.HasKey("IdCurrency");

                    b.ToTable("Currencys");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Journal", b =>
                {
                    b.Property<int>("IdJournal")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Amount");

                    b.Property<DateTime>("DateAmount");

                    b.Property<int>("IdAccount");

                    b.Property<int>("IdCurrency");

                    b.Property<int>("IdOperation");

                    b.Property<float>("TotalCommision");

                    b.HasKey("IdJournal");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdCurrency");

                    b.HasIndex("IdOperation");

                    b.ToTable("Journal");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Operations", b =>
                {
                    b.Property<int>("IdOperation")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdCommision");

                    b.Property<string>("Operation");

                    b.HasKey("IdOperation");

                    b.HasIndex("IdCommision");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("IdUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Accounts", b =>
                {
                    b.HasOne("BankingProyect.Models.Entity.Clients")
                        .WithMany("Accounts")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Clients", b =>
                {
                    b.HasOne("BankingProyect.Models.Entity.Users")
                        .WithMany("Clients")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Journal", b =>
                {
                    b.HasOne("BankingProyect.Models.Entity.Accounts")
                        .WithMany("Journal")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankingProyect.Models.Entity.Currencys")
                        .WithMany("Journal")
                        .HasForeignKey("IdCurrency")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BankingProyect.Models.Entity.Operations")
                        .WithMany("Journal")
                        .HasForeignKey("IdOperation")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BankingProyect.Models.Entity.Operations", b =>
                {
                    b.HasOne("BankingProyect.Models.Entity.Commisions")
                        .WithMany("Operations")
                        .HasForeignKey("IdCommision")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}