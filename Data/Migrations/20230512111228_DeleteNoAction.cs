using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Paciente_PacienteId",
                table: "Diagnostico");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Paciente_PacienteId",
                table: "Diagnostico",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnostico_Paciente_PacienteId",
                table: "Diagnostico");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnostico_Paciente_PacienteId",
                table: "Diagnostico",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id");
        }
    }
}
