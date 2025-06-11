using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_loja_veiculos.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriaToVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Veiculos");
        }
    }
}
