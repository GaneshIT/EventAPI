using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventData.Migrations
{
    /// <inheritdoc />
    public partial class schedule12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventModel_EventModel_EventModelId",
                table: "EventModel");

            migrationBuilder.DropIndex(
                name: "IX_EventModel_EventModelId",
                table: "EventModel");

            migrationBuilder.DropColumn(
                name: "EventModelId",
                table: "EventModel");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_schedule_EventId",
                table: "schedule",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_EventModel_EventId",
                table: "schedule",
                column: "EventId",
                principalTable: "EventModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_EventModel_EventId",
                table: "schedule");

            migrationBuilder.DropIndex(
                name: "IX_schedule_EventId",
                table: "schedule");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "schedule",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventModelId",
                table: "EventModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventModel_EventModelId",
                table: "EventModel",
                column: "EventModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventModel_EventModel_EventModelId",
                table: "EventModel",
                column: "EventModelId",
                principalTable: "EventModel",
                principalColumn: "Id");
        }
    }
}
