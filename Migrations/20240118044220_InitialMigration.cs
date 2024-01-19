using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BankingProyect.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    IdJournal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    DateAmount = table.Column<DateTime>(nullable: false),
                    TotalCommision = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.IdJournal);
                });

            migrationBuilder.CreateTable(
                name: "Acounts",
                columns: table => new
                {
                    IdAccount = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Account = table.Column<string>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    JournalIdJournal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acounts", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Acounts_Journal_JournalIdJournal",
                        column: x => x.JournalIdJournal,
                        principalTable: "Journal",
                        principalColumn: "IdJournal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Currencys",
                columns: table => new
                {
                    IdCurrency = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Currency = table.Column<string>(nullable: true),
                    JournalIdJournal = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencys", x => x.IdCurrency);
                    table.ForeignKey(
                        name: "FK_Currencys_Journal_JournalIdJournal",
                        column: x => x.JournalIdJournal,
                        principalTable: "Journal",
                        principalColumn: "IdJournal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    IdOperation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JournalIdJournal = table.Column<int>(nullable: true),
                    Operation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.IdOperation);
                    table.ForeignKey(
                        name: "FK_Operations_Journal_JournalIdJournal",
                        column: x => x.JournalIdJournal,
                        principalTable: "Journal",
                        principalColumn: "IdJournal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountsIdAccount = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Acounts_AccountsIdAccount",
                        column: x => x.AccountsIdAccount,
                        principalTable: "Acounts",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commisions",
                columns: table => new
                {
                    IdCommision = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Commision = table.Column<decimal>(nullable: false),
                    OperationsIdOperation = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commisions", x => x.IdCommision);
                    table.ForeignKey(
                        name: "FK_Commisions_Operations_OperationsIdOperation",
                        column: x => x.OperationsIdOperation,
                        principalTable: "Operations",
                        principalColumn: "IdOperation",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acounts_JournalIdJournal",
                table: "Acounts",
                column: "JournalIdJournal");

            migrationBuilder.CreateIndex(
                name: "IX_Commisions_OperationsIdOperation",
                table: "Commisions",
                column: "OperationsIdOperation");

            migrationBuilder.CreateIndex(
                name: "IX_Currencys_JournalIdJournal",
                table: "Currencys",
                column: "JournalIdJournal");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_JournalIdJournal",
                table: "Operations",
                column: "JournalIdJournal");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountsIdAccount",
                table: "Users",
                column: "AccountsIdAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commisions");

            migrationBuilder.DropTable(
                name: "Currencys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Acounts");

            migrationBuilder.DropTable(
                name: "Journal");
        }
    }
}
