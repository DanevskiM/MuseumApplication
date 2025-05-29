using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuseumApplication.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "VisitorInHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "VisitorId",
                table: "VisitorInHistories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "visitId",
                table: "VisitorInHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "visitorHistoryId",
                table: "VisitorInHistories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "VisitorHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "VisitorHistories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorInHistories_visitId",
                table: "VisitorInHistories",
                column: "visitId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorInHistories_visitorHistoryId",
                table: "VisitorInHistories",
                column: "visitorHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorInHistories_VisitorId",
                table: "VisitorInHistories",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitorHistories_UserId",
                table: "VisitorHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorHistories_AspNetUsers_UserId",
                table: "VisitorHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorInHistories_VisitorHistories_visitorHistoryId",
                table: "VisitorInHistories",
                column: "visitorHistoryId",
                principalTable: "VisitorHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorInHistories_Visitors_VisitorId",
                table: "VisitorInHistories",
                column: "VisitorId",
                principalTable: "Visitors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitorInHistories_Visits_visitId",
                table: "VisitorInHistories",
                column: "visitId",
                principalTable: "Visits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitorHistories_AspNetUsers_UserId",
                table: "VisitorHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorInHistories_VisitorHistories_visitorHistoryId",
                table: "VisitorInHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorInHistories_Visitors_VisitorId",
                table: "VisitorInHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitorInHistories_Visits_visitId",
                table: "VisitorInHistories");

            migrationBuilder.DropIndex(
                name: "IX_VisitorInHistories_visitId",
                table: "VisitorInHistories");

            migrationBuilder.DropIndex(
                name: "IX_VisitorInHistories_visitorHistoryId",
                table: "VisitorInHistories");

            migrationBuilder.DropIndex(
                name: "IX_VisitorInHistories_VisitorId",
                table: "VisitorInHistories");

            migrationBuilder.DropIndex(
                name: "IX_VisitorHistories_UserId",
                table: "VisitorHistories");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "VisitorInHistories");

            migrationBuilder.DropColumn(
                name: "VisitorId",
                table: "VisitorInHistories");

            migrationBuilder.DropColumn(
                name: "visitId",
                table: "VisitorInHistories");

            migrationBuilder.DropColumn(
                name: "visitorHistoryId",
                table: "VisitorInHistories");

            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "VisitorHistories");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "VisitorHistories");
        }
    }
}
