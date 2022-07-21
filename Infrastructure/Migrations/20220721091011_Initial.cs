using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpensesIncomes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TurnoverType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensesIncomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExpenseIncomeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_ExpensesIncomes_ExpenseIncomeId",
                        column: x => x.ExpenseIncomeId,
                        principalTable: "ExpensesIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpensesIncomes",
                columns: new[] { "Id", "Name", "TurnoverType" },
                values: new object[,]
                {
                    { new Guid("0bfcfc88-bb72-498d-b2de-8592497ad7c8"), "Transportation", 0 },
                    { new Guid("193554b0-d180-4b95-8a38-10c0f9725036"), "Other", 1 },
                    { new Guid("705ba70e-cf28-455d-8c9e-743384b3692c"), "Internet", 0 },
                    { new Guid("7653978a-0820-4cf8-a10c-52ee85524b17"), "Other", 0 },
                    { new Guid("7f4585b2-0a82-4f3b-bd96-37ce4c63e621"), "Food", 0 },
                    { new Guid("9d4b8996-1c79-4a5c-a09b-7a973e6fca80"), "Real estate rent", 1 },
                    { new Guid("b0c8d995-6251-434d-abb0-901bfa254b15"), "Entertainment", 0 },
                    { new Guid("d83da0a5-0e14-4e66-bdcb-d6391048f407"), "Salary", 1 },
                    { new Guid("dd501e53-60ce-471e-b10f-9b9c596e6144"), "Mobile connection", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Records_ExpenseIncomeId",
                table: "Records",
                column: "ExpenseIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserId",
                table: "Records",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "ExpensesIncomes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
