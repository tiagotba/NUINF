using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NUINFDAO.Migrations
{
    public partial class NUINFV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BD_Nuinf_Context");

            migrationBuilder.CreateTable(
                name: "TB_PESSOA",
                schema: "BD_Nuinf_Context",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOM_PESSOA = table.Column<string>(maxLength: 500, nullable: false),
                    CPF_PESSOA = table.Column<string>(nullable: false),
                    DT_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PESSOA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TB_TELEFONE",
                schema: "BD_Nuinf_Context",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DDD_TEL_PESSOA = table.Column<string>(maxLength: 5, nullable: false),
                    DDD_FONE_PESSOA = table.Column<string>(maxLength: 30, nullable: false),
                    Pessoaid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TELEFONE", x => x.id);
                    table.ForeignKey(
                        name: "FK_TB_TELEFONE_TB_PESSOA_Pessoaid",
                        column: x => x.Pessoaid,
                        principalSchema: "BD_Nuinf_Context",
                        principalTable: "TB_PESSOA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TELEFONE_Pessoaid",
                schema: "BD_Nuinf_Context",
                table: "TB_TELEFONE",
                column: "Pessoaid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TELEFONE",
                schema: "BD_Nuinf_Context");

            migrationBuilder.DropTable(
                name: "TB_PESSOA",
                schema: "BD_Nuinf_Context");
        }
    }
}
