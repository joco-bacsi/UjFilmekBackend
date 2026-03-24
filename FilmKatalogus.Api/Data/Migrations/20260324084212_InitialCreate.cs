using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmKatalogus.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mufajok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mufajok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nyelvek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nyelvek", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rendezo = table.Column<string>(type: "TEXT", nullable: false),
                    Cim = table.Column<string>(type: "TEXT", nullable: false),
                    MufajId = table.Column<int>(type: "INTEGER", nullable: false),
                    MegjelenesiDatum = table.Column<int>(type: "INTEGER", nullable: false),
                    Hossz = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    NyelvId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImDbErtekeles = table.Column<double>(type: "REAL", nullable: false),
                    SajatErtekeles = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmek_Mufajok_MufajId",
                        column: x => x.MufajId,
                        principalTable: "Mufajok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filmek_Nyelvek_NyelvId",
                        column: x => x.NyelvId,
                        principalTable: "Nyelvek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmek_MufajId",
                table: "Filmek",
                column: "MufajId");

            migrationBuilder.CreateIndex(
                name: "IX_Filmek_NyelvId",
                table: "Filmek",
                column: "NyelvId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmek");

            migrationBuilder.DropTable(
                name: "Mufajok");

            migrationBuilder.DropTable(
                name: "Nyelvek");
        }
    }
}
