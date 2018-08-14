using Microsoft.EntityFrameworkCore.Migrations;

namespace NUINFDAO.Migrations
{
    public partial class NUINFV5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BD_Nuinf");

            migrationBuilder.RenameTable(
                name: "TB_TELEFONE",
                schema: "BD_Nuinf_Context",
                newName: "TB_TELEFONE",
                newSchema: "BD_Nuinf");

            migrationBuilder.RenameTable(
                name: "TB_PESSOA",
                schema: "BD_Nuinf_Context",
                newName: "TB_PESSOA",
                newSchema: "BD_Nuinf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BD_Nuinf_Context");

            migrationBuilder.RenameTable(
                name: "TB_TELEFONE",
                schema: "BD_Nuinf",
                newName: "TB_TELEFONE",
                newSchema: "BD_Nuinf_Context");

            migrationBuilder.RenameTable(
                name: "TB_PESSOA",
                schema: "BD_Nuinf",
                newName: "TB_PESSOA",
                newSchema: "BD_Nuinf_Context");
        }
    }
}
