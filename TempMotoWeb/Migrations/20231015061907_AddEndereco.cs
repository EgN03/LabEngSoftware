using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TempMotoWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "endereco",
                table: "Medicao",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endereco",
                table: "Medicao");
        }
    }
}
