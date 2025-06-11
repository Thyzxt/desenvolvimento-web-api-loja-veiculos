using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_loja_veiculos.Migrations
{
    /// <inheritdoc />
    public partial class AddDescricaoToVeiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Veiculos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Veiculos");
        }
    }
}
