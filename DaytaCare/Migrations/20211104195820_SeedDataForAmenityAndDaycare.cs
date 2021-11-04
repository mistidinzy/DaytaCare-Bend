using Microsoft.EntityFrameworkCore.Migrations;

namespace DaytaCare.Migrations
{
    public partial class SeedDataForAmenityAndDaycare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Parking" },
                    { 2, "Indoor Playground" },
                    { 3, "Pay Scaling" },
                    { 4, "Shuttle Transportation" },
                    { 5, "Security" },
                    { 6, "Wheelchair Accessible" },
                    { 7, "Education" },
                    { 8, "Meal Plan" }
                });

            migrationBuilder.InsertData(
                table: "Daycares",
                columns: new[] { "Id", "Availability", "City", "Country", "DaycareType", "Email", "LicenseNumber", "Name", "OwnerId", "Phone", "Price", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, true, "Cedar Rapids", "United States", 5, "KidsPoint@example.com", 1, "KidsPoint Downtown Learning Center & Preschool", null, "(319) 365-1636", 200m, "Iowa", "318 5th St SE" },
                    { 2, true, "Cedar Rapids", "United States", 5, "TeddyBear@example.com", 2, "Teddy Bear Child Care Center Inc", null, "(319) 365-6534", 210m, "Iowa", "2730 Bowling St SW" },
                    { 3, true, "Iowa City", "United States", 5, "iowa4cshometies@yahoo.com", 3, "Home Ties Child Care Center", null, "(319) 341-0050", 190m, "Iowa", "405 Myrtle Ave" },
                    { 4, false, "Iowa City", "United States", 1, "alicesrainbowchildcarecenters@gmail.com", 4, "Alice's Rainbow Child Care Center", null, "(319) 354-1466", 225m, "Iowa", "421 Melrose Ave" },
                    { 5, true, "Marion", "United States", 5, "KidsInc@example.com", 5, "KIDS INC.", null, "(319) 447-6316", 200m, "Iowa", "1100 35th St" }
                });

            migrationBuilder.InsertData(
                table: "DaycareAmenities",
                columns: new[] { "AmenityId", "DaycareId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 7, 2 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 4 },
                    { 8, 5 },
                    { 5, 5 },
                    { 6, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "DaycareAmenities",
                keyColumns: new[] { "AmenityId", "DaycareId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Daycares",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Daycares",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Daycares",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Daycares",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Daycares",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
