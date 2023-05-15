using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class EnfermedadPacienteEnfermedad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Riesgo = table.Column<int>(type: "int", nullable: false),
                    DiasTratamiento = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermedad_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacienteEnfermedad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnfermedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteEnfermedad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteEnfermedad_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PacienteEnfermedad_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermedad_AreaId",
                table: "Enfermedad",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteEnfermedad_EnfermedadId",
                table: "PacienteEnfermedad",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteEnfermedad_PacienteId",
                table: "PacienteEnfermedad",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PacienteEnfermedad");

            migrationBuilder.DropTable(
                name: "Enfermedad");
        }
    }
}
