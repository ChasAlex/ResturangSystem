using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResturangSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kund",
                columns: table => new
                {
                    KundId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kund", x => x.KundId);
                });

            migrationBuilder.CreateTable(
                name: "Restaurang",
                columns: table => new
                {
                    RestaurangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurang", x => x.RestaurangId);
                });

            migrationBuilder.CreateTable(
                name: "Bord",
                columns: table => new
                {
                    BordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bordsnummer = table.Column<int>(type: "int", nullable: false),
                    Platser = table.Column<int>(type: "int", nullable: false),
                    BoolBokad = table.Column<bool>(type: "bit", nullable: false),
                    RestaurangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bord", x => x.BordId);
                    table.ForeignKey(
                        name: "FK_Bord_Restaurang_RestaurangId",
                        column: x => x.RestaurangId,
                        principalTable: "Restaurang",
                        principalColumn: "RestaurangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meny",
                columns: table => new
                {
                    MenyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tillgänglig = table.Column<bool>(type: "bit", nullable: false),
                    RestaurangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meny", x => x.MenyId);
                    table.ForeignKey(
                        name: "FK_Meny_Restaurang_RestaurangId",
                        column: x => x.RestaurangId,
                        principalTable: "Restaurang",
                        principalColumn: "RestaurangId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bokning",
                columns: table => new
                {
                    BokningId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Antal = table.Column<int>(type: "int", nullable: false),
                    KundId = table.Column<int>(type: "int", nullable: false),
                    BordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bokning", x => x.BokningId);
                    table.ForeignKey(
                        name: "FK_Bokning_Bord_BordId",
                        column: x => x.BordId,
                        principalTable: "Bord",
                        principalColumn: "BordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bokning_Kund_KundId",
                        column: x => x.KundId,
                        principalTable: "Kund",
                        principalColumn: "KundId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kund",
                columns: new[] { "KundId", "Email", "Namn" },
                values: new object[,]
                {
                    { 1, "kunda@example.com", "Kund A" },
                    { 2, "kundb@example.com", "Kund B" }
                });

            migrationBuilder.InsertData(
                table: "Restaurang",
                columns: new[] { "RestaurangId", "Namn" },
                values: new object[,]
                {
                    { 1, "Restaurang A" },
                    { 2, "Restaurang B" }
                });

            migrationBuilder.InsertData(
                table: "Bord",
                columns: new[] { "BordId", "BoolBokad", "Bordsnummer", "Platser", "RestaurangId" },
                values: new object[,]
                {
                    { 1, false, 101, 4, 1 },
                    { 2, false, 102, 2, 1 },
                    { 3, false, 201, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Meny",
                columns: new[] { "MenyId", "Namn", "Pris", "RestaurangId", "Tillgänglig" },
                values: new object[,]
                {
                    { 1, "Rätt A", 100m, 1, true },
                    { 2, "Rätt B", 150m, 1, false },
                    { 3, "Rätt C", 120m, 2, true }
                });

            migrationBuilder.InsertData(
                table: "Bokning",
                columns: new[] { "BokningId", "Antal", "BordId", "Datum", "KundId" },
                values: new object[,]
                {
                    { 1, 2, 1, new DateTime(2024, 8, 27, 11, 2, 39, 648, DateTimeKind.Local).AddTicks(2555), 1 },
                    { 2, 4, 3, new DateTime(2024, 8, 28, 11, 2, 39, 648, DateTimeKind.Local).AddTicks(2595), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_BordId",
                table: "Bokning",
                column: "BordId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokning_KundId",
                table: "Bokning",
                column: "KundId");

            migrationBuilder.CreateIndex(
                name: "IX_Bord_RestaurangId",
                table: "Bord",
                column: "RestaurangId");

            migrationBuilder.CreateIndex(
                name: "IX_Meny_RestaurangId",
                table: "Meny",
                column: "RestaurangId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bokning");

            migrationBuilder.DropTable(
                name: "Meny");

            migrationBuilder.DropTable(
                name: "Bord");

            migrationBuilder.DropTable(
                name: "Kund");

            migrationBuilder.DropTable(
                name: "Restaurang");
        }
    }
}
