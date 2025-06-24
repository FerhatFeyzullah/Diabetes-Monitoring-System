using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DiabetesMonitoringSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_added_to_alerts_timePeriod_property_and_deleted_messages_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Messages_MessageId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_MessageId",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "MessageId",
                table: "Alerts",
                newName: "TimePeriod");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "AlertDate",
                table: "Alerts",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Alerts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Alerts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "TimePeriod",
                table: "Alerts",
                newName: "MessageId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AlertDate",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_MessageId",
                table: "Alerts",
                column: "MessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Messages_MessageId",
                table: "Alerts",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "MessageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
