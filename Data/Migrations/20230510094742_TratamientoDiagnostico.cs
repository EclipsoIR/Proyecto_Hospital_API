using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TratamientoDiagnostico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedad_Area_AreaId",
                table: "Enfermedad");

            migrationBuilder.DropColumn(
                name: "DiasTratamiento",
                table: "Enfermedad");

            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnostico_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Diagnostico_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    EnfermedadId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamiento_Enfermedad_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TratamientoDiagnostico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TratamientoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiagnosticoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientoDiagnostico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientoDiagnostico_Diagnostico_DiagnosticoId",
                        column: x => x.DiagnosticoId,
                        principalTable: "Diagnostico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TratamientoDiagnostico_Tratamiento_TratamientoId",
                        column: x => x.TratamientoId,
                        principalTable: "Tratamiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_MedicoId",
                table: "Diagnostico",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostico_PacienteId",
                table: "Diagnostico",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_EnfermedadId",
                table: "Tratamiento",
                column: "EnfermedadId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoDiagnostico_DiagnosticoId",
                table: "TratamientoDiagnostico",
                column: "DiagnosticoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientoDiagnostico_TratamientoId",
                table: "TratamientoDiagnostico",
                column: "TratamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedad_Area_AreaId",
                table: "Enfermedad",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enfermedad_Area_AreaId",
                table: "Enfermedad");

            migrationBuilder.DropTable(
                name: "TratamientoDiagnostico");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Tratamiento");

            migrationBuilder.AddColumn<int>(
                name: "DiasTratamiento",
                table: "Enfermedad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Enfermedad_Area_AreaId",
                table: "Enfermedad",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
