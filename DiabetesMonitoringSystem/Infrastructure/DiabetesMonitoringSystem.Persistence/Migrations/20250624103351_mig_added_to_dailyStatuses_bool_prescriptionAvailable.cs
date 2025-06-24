using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiabetesMonitoringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_added_to_dailyStatuses_bool_prescriptionAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrescriptionAvailable",
                table: "DailyStatuses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrescriptionAvailable",
                table: "DailyStatuses");
        }
    }
}
