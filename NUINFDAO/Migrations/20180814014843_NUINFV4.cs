using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NUINFDAO.Migrations
{
    public partial class NUINFV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_NASCIMENTO",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_NASCIMENTO",
                schema: "BD_Nuinf_Context",
                table: "TB_PESSOA",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
