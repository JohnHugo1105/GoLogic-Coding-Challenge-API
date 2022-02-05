using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoLogic.BookingPlatform.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    Description = table.Column<string>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    RoomCapacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    NumberOfGuest = table.Column<int>(nullable: false),
                    CheckInDate = table.Column<DateTime>(nullable: false),
                    CheckOutDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomImages_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "Melbourne", "Australia", 3000L, "Victoria" },
                    { 2, "Morpeth", "Australia", 2321L, "New South Wales" },
                    { 3, "Smithton", "Australia", 7330L, "Tasmania" },
                    { 4, "Cannonvale", "Australia", 4802L, "Queensland" },
                    { 5, "Kurmond", "Australia", 2754L, "New South Wales" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password" },
                values: new object[] { 1, "user@gmail.com", "John Thompson", "12345" });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "AddressId", "Description", "Price", "RoomCapacity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Oaks Melbourne on Lonsdale Suites is surrounded by fabulous shopping, restaurants, cafés, the vibrant theater district and Chinatown. The iconic MCG and Rod Laver Arena are each a 20-minute walk away.", 136.30m, 2, "Oaks Melbourne on Lonsdale Suites" },
                    { 2, 2, "Hunter Oasis has an outdoor swimming pool, fitness center, a shared lounge and garden in Morpeth. Among the facilities at this property are a 24-hour front desk and a shared kitchen, along with free WiFi throughout the property. The motel features family rooms.", 120m, 5, "Hunter Oasis" },
                    { 3, 3, "Bridge Hotel has a restaurant, bar, a shared lounge and garden in Smithton. The property has a shared kitchen and room service for guests.", 152.30m, 3, "Bridge Hotel" },
                    { 4, 4, "Located in Cannonvale, 6.1 mi from Airlie Beach, this property offers a unique wildlife experience in a tranquil Australian bush setting. Airlie Beach Eco Cabins features accommodations with free WiFi and is 2.6 mi from Whitsunday Plaza.", 146.10m, 2, "Airlie Beach Eco Cabins" },
                    { 5, 5, "Featuring air-conditioned accommodations with a balcony, A place to be is located in Kurmond. The property is 45.1 km from Liverpool and free private parking is featured.", 176.80m, 3, "A place to be" }
                });

            migrationBuilder.InsertData(
                table: "RoomImages",
                columns: new[] { "Id", "ImageName", "RoomId" },
                values: new object[,]
                {
                    { 1, "RoomA1.jpg", 1 },
                    { 2, "RoomA2.jpg", 1 },
                    { 3, "RoomA3.jpg", 1 },
                    { 4, "RoomB1.jpg", 2 },
                    { 5, "RoomB2.jpg", 2 },
                    { 6, "RoomB3.jpg", 2 },
                    { 7, "RoomC1.jpg", 3 },
                    { 8, "RoomC2.jpg", 3 },
                    { 9, "RoomC3.jpg", 3 },
                    { 10, "RoomD1.jpg", 4 },
                    { 11, "RoomD2.jpg", 4 },
                    { 12, "RoomD3.jpg", 4 },
                    { 13, "RoomE1.jpg", 5 },
                    { 14, "RoomE2.jpg", 5 },
                    { 15, "RoomE3.jpg", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomId",
                table: "RoomImages",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AddressId",
                table: "Rooms",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
