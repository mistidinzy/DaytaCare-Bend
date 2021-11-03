using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class AddedNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities");

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities",
                column: "AmenityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_DaycareId",
                table: "DaycareAmenities",
                column: "DaycareId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities");

            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_DaycareId",
                table: "DaycareAmenities");

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities",
                column: "AmenityId");
        }
    }
}
