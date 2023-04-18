using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeiraApiConsulta.Migrations
{
    /// <inheritdoc />
    public partial class _0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "Pessoa");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Pessoa",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Endereco",
                table: "Pessoa",
                newName: "endereco");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Pessoa",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Cep",
                table: "Pessoa",
                newName: "cep");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Pessoa",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Pessoas",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "endereco",
                table: "Pessoas",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Pessoas",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "cep",
                table: "Pessoas",
                newName: "Cep");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Pessoas",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");
        }
    }
}
