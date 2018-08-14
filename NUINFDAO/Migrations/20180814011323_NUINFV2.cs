using Microsoft.EntityFrameworkCore.Migrations;

namespace NUINFDAO.Migrations
{
    public partial class NUINFV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                newName: "EMAIL_PESSOA");

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_PESSOA",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMAIL_PESSOA",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
