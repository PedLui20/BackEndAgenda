using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppAgenda.Infraestructure.Database.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AGD");

            migrationBuilder.CreateTable(
                name: "Evento",
                schema: "AGD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidadParticipantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                schema: "AGD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "AGD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EventoParticipante",
                schema: "AGD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEvento = table.Column<int>(type: "int", nullable: false),
                    idParticipante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoParticipante", x => x.id);
                    table.ForeignKey(
                        name: "FK_EventoParticipante_Evento_idEvento",
                        column: x => x.idEvento,
                        principalSchema: "AGD",
                        principalTable: "Evento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoParticipante_Participante_idParticipante",
                        column: x => x.idParticipante,
                        principalSchema: "AGD",
                        principalTable: "Participante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                schema: "AGD",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    idEvento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.id);
                    table.ForeignKey(
                        name: "FK_Agenda_Evento_idEvento",
                        column: x => x.idEvento,
                        principalSchema: "AGD",
                        principalTable: "Evento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agenda_Usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalSchema: "AGD",
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_idEvento",
                schema: "AGD",
                table: "Agenda",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_idUsuario",
                schema: "AGD",
                table: "Agenda",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_EventoParticipante_idEvento",
                schema: "AGD",
                table: "EventoParticipante",
                column: "idEvento");

            migrationBuilder.CreateIndex(
                name: "IX_EventoParticipante_idParticipante",
                schema: "AGD",
                table: "EventoParticipante",
                column: "idParticipante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda",
                schema: "AGD");

            migrationBuilder.DropTable(
                name: "EventoParticipante",
                schema: "AGD");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "AGD");

            migrationBuilder.DropTable(
                name: "Evento",
                schema: "AGD");

            migrationBuilder.DropTable(
                name: "Participante",
                schema: "AGD");
        }
    }
}
