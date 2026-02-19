using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Tiere",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Anfragen",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TextInfo",
                table: "Anfragen",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Tiere");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Anfragen");

            migrationBuilder.DropColumn(
                name: "TextInfo",
                table: "Anfragen");
        }
    }
}
