using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiabetesMonitoringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_deleted_patientSymptom_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientSymptoms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientSymptoms",
                columns: table => new
                {
                    PatientSymptomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    SymptomId = table.Column<int>(type: "integer", nullable: false),
                    SymptomDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientSymptoms", x => x.PatientSymptomId);
                    table.ForeignKey(
                        name: "FK_PatientSymptoms_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientSymptoms_Symptoms_SymptomId",
                        column: x => x.SymptomId,
                        principalTable: "Symptoms",
                        principalColumn: "SymptomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientSymptoms_PatientId",
                table: "PatientSymptoms",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientSymptoms_SymptomId",
                table: "PatientSymptoms",
                column: "SymptomId");
        }
    }
}
