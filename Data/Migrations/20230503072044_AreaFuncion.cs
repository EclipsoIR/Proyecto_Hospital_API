using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AreaFuncion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "Funcion",
                table: "Medico");

            migrationBuilder.AddColumn<Guid>(
                name: "FuncionId",
                table: "Medico",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tamaño = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcion_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_FuncionId",
                table: "Medico",
                column: "FuncionId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_HospitalId",
                table: "Area",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcion_AreaId",
                table: "Funcion",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medico_Funcion_FuncionId",
                table: "Medico",
                column: "FuncionId",
                principalTable: "Funcion",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medico_Funcion_FuncionId",
                table: "Medico");

            migrationBuilder.DropTable(
                name: "Funcion");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Medico_FuncionId",
                table: "Medico");

            migrationBuilder.DropColumn(
                name: "FuncionId",
                table: "Medico");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Funcion",
                table: "Medico",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
