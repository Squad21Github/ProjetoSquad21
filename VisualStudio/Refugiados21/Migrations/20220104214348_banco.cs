using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Refugiados1.Migrations
{
    public partial class banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CriarDadiva",
                columns: table => new
                {
                    IdCriarDadiva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dadiva = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriarDadiva", x => x.IdCriarDadiva);
                });

            migrationBuilder.CreateTable(
                name: "SolicitarDadiva",
                columns: table => new
                {
                    IdDadiva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dádiva = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitarDadiva", x => x.IdDadiva);
                });

            migrationBuilder.CreateTable(
                name: "EscolherDadiva",
                columns: table => new
                {
                    IdEscolherDadiva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereço = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCriarDadiva = table.Column<int>(type: "int", nullable: false),
                    IdNome = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolherDadiva", x => x.IdEscolherDadiva);
                    table.ForeignKey(
                        name: "FK_EscolherDadiva_CriarDadiva_IdCriarDadiva",
                        column: x => x.IdCriarDadiva,
                        principalTable: "CriarDadiva",
                        principalColumn: "IdCriarDadiva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtenderDadiva",
                columns: table => new
                {
                    IdAtender = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Seu_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdDadiva = table.Column<int>(type: "int", nullable: false),
                    IdOng = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtenderDadiva", x => x.IdAtender);
                    table.ForeignKey(
                        name: "FK_AtenderDadiva_SolicitarDadiva_IdDadiva",
                        column: x => x.IdDadiva,
                        principalTable: "SolicitarDadiva",
                        principalColumn: "IdDadiva",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtenderDadiva_IdDadiva",
                table: "AtenderDadiva",
                column: "IdDadiva");

            migrationBuilder.CreateIndex(
                name: "IX_EscolherDadiva_IdCriarDadiva",
                table: "EscolherDadiva",
                column: "IdCriarDadiva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtenderDadiva");

            migrationBuilder.DropTable(
                name: "EscolherDadiva");

            migrationBuilder.DropTable(
                name: "SolicitarDadiva");

            migrationBuilder.DropTable(
                name: "CriarDadiva");
        }
    }
}
