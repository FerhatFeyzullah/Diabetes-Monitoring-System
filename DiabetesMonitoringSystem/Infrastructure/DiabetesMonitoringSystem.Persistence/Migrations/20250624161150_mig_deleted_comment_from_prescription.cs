using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiabetesMonitoringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_deleted_comment_from_prescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Prescriptions");

            migrationBuilder.AddColumn<List<string>>(
                name: "Symptoms",
                table: "BloodSugars",
                type: "text[]",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "BloodSugars");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Prescriptions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
