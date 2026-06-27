using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AprovadosConcursosApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bancas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orgaos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orgaos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplinaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assuntos_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assuntos_Disciplinas_DisciplinaId1",
                        column: x => x.DisciplinaId1,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Editais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroEdital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeVagas = table.Column<int>(type: "int", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DataPublicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInscricaoInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInscricaoFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataProva = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LinkEdital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrgaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CargoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrgaoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Editais_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Editais_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Editais_Cargos_CargoId1",
                        column: x => x.CargoId1,
                        principalTable: "Cargos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Editais_Orgaos_OrgaoId",
                        column: x => x.OrgaoId,
                        principalTable: "Orgaos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Editais_Orgaos_OrgaoId1",
                        column: x => x.OrgaoId1,
                        principalTable: "Orgaos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enunciado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativaA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativaB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativaC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativaD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlternativaE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gabarito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisciplinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssuntoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssuntoId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DisciplinaId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questoes_Assuntos_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assuntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questoes_Assuntos_AssuntoId1",
                        column: x => x.AssuntoId1,
                        principalTable: "Assuntos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questoes_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questoes_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questoes_Disciplinas_DisciplinaId1",
                        column: x => x.DisciplinaId1,
                        principalTable: "Disciplinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assuntos_DisciplinaId",
                table: "Assuntos",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Assuntos_DisciplinaId1",
                table: "Assuntos",
                column: "DisciplinaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_BancaId",
                table: "Editais",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_CargoId",
                table: "Editais",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_CargoId1",
                table: "Editais",
                column: "CargoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_OrgaoId",
                table: "Editais",
                column: "OrgaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Editais_OrgaoId1",
                table: "Editais",
                column: "OrgaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_AssuntoId",
                table: "Questoes",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_AssuntoId1",
                table: "Questoes",
                column: "AssuntoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_BancaId",
                table: "Questoes",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_DisciplinaId",
                table: "Questoes",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_DisciplinaId1",
                table: "Questoes",
                column: "DisciplinaId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Editais");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Orgaos");

            migrationBuilder.DropTable(
                name: "Assuntos");

            migrationBuilder.DropTable(
                name: "Bancas");

            migrationBuilder.DropTable(
                name: "Disciplinas");
        }
    }
}
