using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ONGNET.Migrations
{
    /// <inheritdoc />
    public partial class CriandoATabelaPrimeiraVez : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDaResidencia",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDoTelefone",
                table: "Users",
                type: "TEXT",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Representante",
                table: "Users",
                type: "TEXT",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumeroDaResidencia",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumeroDoTelefone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Representante",
                table: "Users");
        }
    }
}
