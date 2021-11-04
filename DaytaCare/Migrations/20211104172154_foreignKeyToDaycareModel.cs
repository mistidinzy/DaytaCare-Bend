using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class foreignKeyToDaycareModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Daycares",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daycares_OwnerId",
                table: "Daycares",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Daycares_AspNetUsers_OwnerId",
                table: "Daycares",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daycares_AspNetUsers_OwnerId",
                table: "Daycares");

            migrationBuilder.DropIndex(
                name: "IX_Daycares_OwnerId",
                table: "Daycares");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Daycares");
        }
    }
}
