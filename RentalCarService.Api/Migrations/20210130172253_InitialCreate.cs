using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentalCarService.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarCategoryID = table.Column<int>(type: "int", nullable: false),
                    RentalStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MilageRegistrated = table.Column<int>(type: "int", nullable: false),
                    MilageReturned = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Regnr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Milage = table.Column<int>(type: "int", nullable: false),
                    CarTypeID = table.Column<int>(type: "int", nullable: false),
                    Booked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "BookingID", "BookingNumber", "CarCategoryID", "CarID", "CustomerDateOfBirth", "MilageRegistrated", "MilageReturned", "Price", "RentalEnd", "RentalStart" },
                values: new object[] { 12, "125040", 2, 3, "1212121212", 15270, 0, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 18, 18, 22, 53, 162, DateTimeKind.Local).AddTicks(546) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "CarID", "Booked", "CarTypeID", "Milage", "Regnr" },
                values: new object[,]
                {
                    { 1, false, 2, 25800, "CPR100" },
                    { 2, false, 1, 100000, "BXR995" },
                    { 3, true, 3, 15270, "RON222" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
