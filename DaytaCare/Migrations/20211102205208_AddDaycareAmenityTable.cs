using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class AddDaycareAmenityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaycareAmenities",
                columns: table => new
                {
                    DaycareId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaycareAmenities", x => new { x.DaycareId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_DaycareAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaycareAmenities_Daycares_DaycareId",
                        column: x => x.DaycareId,
                        principalTable: "Daycares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DaycareAmenities_AmenityId",
                table: "DaycareAmenities",
                column: "AmenityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaycareAmenities");
        }
    }
}
