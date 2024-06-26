using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiap.Api.Alertas.Migrations
{
    /// <inheritdoc />
    public partial class AdddAlertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Alertas",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Alertas");
        }
    }
}
