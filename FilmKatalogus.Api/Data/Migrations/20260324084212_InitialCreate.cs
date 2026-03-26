using System;
using Microsoft.EntityFrameworkCore.Metadata;
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
                name: "Filmek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Rendezo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cim = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MufajId = table.Column<int>(type: "int", nullable: false),
                    MegjelenesiDatum = table.Column<int>(type: "int", nullable: false),
                    Hossz = table.Column<TimeOnly>(type: "text", nullable: false),
                    Nyelv = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImDbErtekeles = table.Column<double>(type: "double", nullable: false),
                    SajatErtekeles = table.Column<double>(type: "double", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");
            
            migrationBuilder.CreateTable(
                name: "Szineszek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szineszek", x => x.Id);
                });
            
            migrationBuilder.CreateTable(
                name: "FilmCast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SzineszId = table.Column<int>(type: "INTEGER", nullable: false),
                    filmCim = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmCast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmCast_Szineszek_SzineszId",
                        column: x => x.SzineszId,
                        principalTable: "Szineszek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                        table.ForeignKey(
                        name: "FK_FilmCast_Filmek_Cim",
                        column: x => x.filmCim,
                        principalTable: "Filmek",
                        principalColumn: "Cim",
                        onDelete: ReferentialAction.Cascade);
                        
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmek_MufajId",
                table: "Filmek",
                column: "MufajId");

            migrationBuilder.InsertData(
                table: "Mufajok",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                   
            {1, "Action" },
            {2,"Adventure" },
            {3, "Animated" },
            {4, "Comedy" },
            {5, "Drama" },
            {6, "Fantasy" },
            {7, "Historical" },
            {8, "Horror" },
            {9, "Melodrama" },
            {10, "Musical" },
            {11, "Noir" },
            {12, "Romance" },
            {13, "Science fiction" },
            {14, "Thriller" },
            {15, "Western" }
        });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmek");

            migrationBuilder.DropTable(
                name: "Mufajok");

            migrationBuilder.DropTable(
                name: "Szineszek");
            migrationBuilder.DropTable(
                name: "FilmCast");
        }
    }
}
