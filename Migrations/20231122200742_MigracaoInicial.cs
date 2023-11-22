using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace hoop_2.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peladas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dataPelada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duracao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peladas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    numeroJogadores = table.Column<int>(type: "integer", nullable: false),
                    PeladaID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Times_Peladas_PeladaID",
                        column: x => x.PeladaID,
                        principalTable: "Peladas",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Jogadores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Posicao = table.Column<string>(type: "text", nullable: true),
                    Estrelas = table.Column<int>(type: "integer", nullable: false),
                    PeladaID = table.Column<int>(type: "integer", nullable: true),
                    TimeID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogadores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Jogadores_Peladas_PeladaID",
                        column: x => x.PeladaID,
                        principalTable: "Peladas",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Jogadores_Times_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Times",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_PeladaID",
                table: "Jogadores",
                column: "PeladaID");

            migrationBuilder.CreateIndex(
                name: "IX_Jogadores_TimeID",
                table: "Jogadores",
                column: "TimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Times_PeladaID",
                table: "Times",
                column: "PeladaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogadores");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Peladas");
        }
    }
}
