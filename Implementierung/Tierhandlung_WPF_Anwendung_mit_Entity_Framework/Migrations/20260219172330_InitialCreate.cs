using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Nutzer_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Benutzername = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    Passwort = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    is_ADMIN = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__34A15DAD78B473E6", x => x.Nutzer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tiere",
                columns: table => new
                {
                    Tier_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tierart = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    Tiername = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    Geburtsdatum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Beschreibung = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tiere__754A1AE3A57B0B9A", x => x.Tier_ID);
                });

            migrationBuilder.CreateTable(
                name: "Anfragen",
                columns: table => new
                {
                    Anfrage_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nutzer_ID = table.Column<int>(type: "INTEGER", nullable: true),
                    Tier_ID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Anfragen__CB00C311EB80294A", x => x.Anfrage_ID);
                    table.ForeignKey(
                        name: "FK__Anfragen__Nutzer__3B75D760",
                        column: x => x.Nutzer_ID,
                        principalTable: "Account",
                        principalColumn: "Nutzer_ID");
                    table.ForeignKey(
                        name: "FK__Anfragen__Tier_I__3C69FB99",
                        column: x => x.Tier_ID,
                        principalTable: "Tiere",
                        principalColumn: "Tier_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anfragen_Nutzer_ID",
                table: "Anfragen",
                column: "Nutzer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Anfragen_Tier_ID",
                table: "Anfragen",
                column: "Tier_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anfragen");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Tiere");
        }
    }
}
