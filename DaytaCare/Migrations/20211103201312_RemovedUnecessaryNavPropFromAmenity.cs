using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class RemovedUnecessaryNavPropFromAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities");

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities",
                column: "AmenityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities");

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities",
                column: "AmenityId",
                unique: true);
        }
    }
}
