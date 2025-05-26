using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Majo29AV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 1,
                column: "Nombre",
                value: "Director");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "PkRol",
                keyValue: 1,
                column: "Nombre",
                value: "sa");
        }
    }
}
