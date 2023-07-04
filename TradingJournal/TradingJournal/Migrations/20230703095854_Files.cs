using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradingJournal.Migrations
{
    public partial class Files : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userRegistrations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRegistrations", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "journals",
                columns: table => new
                {
                    journalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EntryPrice = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosePrice = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfitorLoss = table.Column<int>(type: "int", nullable: true),
                    JournalTrade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journals", x => x.journalId);
                    table.ForeignKey(
                        name: "FK_journals_userRegistrations_UserId",
                        column: x => x.UserId,
                        principalTable: "userRegistrations",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_journals_UserId",
                table: "journals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "journals");

            migrationBuilder.DropTable(
                name: "userRegistrations");
        }
    }
}
