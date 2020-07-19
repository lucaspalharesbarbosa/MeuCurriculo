using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeuCurriculo.Migrations
{
    public partial class DropDataCadastroEIsDeleteHabilidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Habilidades");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Habilidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Habilidades",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
