using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AVSBiro.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Postions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayRank = table.Column<int>(type: "int", nullable: false),
                    Obsolete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brutto2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidOvertime = table.Column<bool>(type: "bit", nullable: false),
                    EmploymentEnded = table.Column<bool>(type: "bit", nullable: false),
                    Contract = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IBAN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obsolete = table.Column<bool>(type: "bit", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emmployees_Postions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Postions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Postions",
                columns: new[] { "Id", "Name", "Obsolete", "PayRank" },
                values: new object[,]
                {
                    { 1, "PLC Programmer", false, 50000 },
                    { 2, "Junior Developer", false, 10000 }
                });

            migrationBuilder.InsertData(
                table: "Emmployees",
                columns: new[] { "Id", "Brutto2", "Contract", "EmploymentEnded", "FirstName", "IBAN", "LastName", "Obsolete", "PaidOvertime", "PositionId" },
                values: new object[,]
                {
                    { 1, 10000m, "Contract", false, "Nikola", "ibanNikola", "Lovrić", false, false, 1 },
                    { 2, 10000m, "Contract2", false, "Danijel", "ibanDanijel", "Pavić", false, false, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emmployees_PositionId",
                table: "Emmployees",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emmployees");

            migrationBuilder.DropTable(
                name: "Postions");
        }
    }
}
