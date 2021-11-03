using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class AddDeleteDaycareAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DaycareAmenities_DaycareId",
                table: "DaycareAmenities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_DaycareId",
                table: "DaycareAmenities",
                column: "DaycareId",
                unique: true);
        }
    }
}
