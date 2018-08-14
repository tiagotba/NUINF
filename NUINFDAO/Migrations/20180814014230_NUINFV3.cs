using Microsoft.EntityFrameworkCore.Migrations;

namespace NUINFDAO.Migrations
{
    public partial class NUINFV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_PESSOA",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EMAIL_PESSOA",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
