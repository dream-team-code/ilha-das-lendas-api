using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IlhadasLendasAPI.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Ativo"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Ativo"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivo = table.Column<Guid>(type: "uniqueidentifier", maxLength: 300, nullable: false, defaultValueSql: "NEWID()"),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoFisico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NacionalidadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Nick = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CategoriaJogador = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Academy"),
                    Pontuacao = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    UltimaPontuacao = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    MVP = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    Bagre = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivo = table.Column<Guid>(type: "uniqueidentifier", maxLength: 300, nullable: false, defaultValueSql: "NEWID()"),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoFisico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogadores_Nacionalidades_NacionalidadeId",
                        column: x => x.NacionalidadeId,
                        principalTable: "Nacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jogadores_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JogadorTime",
                columns: table => new
                {
                    JogadoresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadorTime", x => new { x.JogadoresId, x.TimesId });
                    table.ForeignKey(
                        name: "FK_JogadorTime_Jogadores_JogadoresId",
                        column: x => x.JogadoresId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JogadorTime_Times_TimesId",
                        column: x => x.TimesId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_NacionalidadeId",
                table: "Jogadores",
                column: "NacionalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_RoleId",
                table: "Jogadores",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_JogadorTime_TimesId",
                table: "JogadorTime",
                column: "TimesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JogadorTime");

            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}