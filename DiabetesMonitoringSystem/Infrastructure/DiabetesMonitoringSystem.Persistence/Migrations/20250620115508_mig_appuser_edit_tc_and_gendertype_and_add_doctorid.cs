using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiabetesMonitoringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_appuser_edit_tc_and_gendertype_and_add_doctorid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TC",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DoctorId",
                table: "AspNetUsers",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "TC",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }
    }
}
