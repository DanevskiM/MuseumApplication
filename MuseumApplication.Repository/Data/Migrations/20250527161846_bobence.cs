using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MuseumApplication.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class bobence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Visits",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_UserId",
                table: "Visits",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visits_AspNetUsers_UserId",
                table: "Visits");

            migrationBuilder.DropIndex(
                name: "IX_Visits_UserId",
                table: "Visits");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Visits");
        }
    }
}
