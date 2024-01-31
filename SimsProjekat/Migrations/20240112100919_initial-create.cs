using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimsProjekat.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Jmbg = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    UserType = table.Column<int>(type: "INTEGER", nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Jmbg);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Jmbg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Jmbg);
                    table.ForeignKey(
                        name: "FK_Admin_User_Jmbg",
                        column: x => x.Jmbg,
                        principalTable: "User",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Jmbg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Jmbg);
                    table.ForeignKey(
                        name: "FK_Guest_User_Jmbg",
                        column: x => x.Jmbg,
                        principalTable: "User",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Jmbg = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Jmbg);
                    table.ForeignKey(
                        name: "FK_Owner_User_Jmbg",
                        column: x => x.Jmbg,
                        principalTable: "User",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ConstructionYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerJmbg = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotel_Owner_OwnerJmbg",
                        column: x => x.OwnerJmbg,
                        principalTable: "Owner",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    RoomCount = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxGuestNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    HotelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GuestJmbg = table.Column<string>(type: "TEXT", nullable: false),
                    ApartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    RejectionReason = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Guest_GuestJmbg",
                        column: x => x.GuestJmbg,
                        principalTable: "Guest",
                        principalColumn: "Jmbg",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Jmbg", "Email", "FirstName", "IsBlocked", "LastName", "Password", "PhoneNumber", "UserType" },
                values: new object[,]
                {
                    { "1111111111111", "guest1@gmail.com", "Mara", false, "Maric", "guest1", "123456789", 1 },
                    { "1234567890123", "admin1@gmail.com", "Marko", false, "Markovic", "admin1", "123456789", 0 },
                    { "2222222222222", "guest2@gmail.com", "Nikola", false, "Nikolic", "guest2", "123456789", 1 },
                    { "3333333333333", "guest3@gmail.com", "Jovana", false, "Jovanic", "guest3", "123456789", 1 },
                    { "4444444444444", "owner1@gmail.com", "Mara", false, "Maric", "owner1", "123456789", 2 },
                    { "4567890123456", "admin2@gmail.com", "Pera", false, "Peric", "admin2", "123456789", 0 },
                    { "5555555555555", "owner2@gmail.com", "Nikola", false, "Nikolic", "owner2", "123456789", 2 },
                    { "6666666666666", "owner3@gmail.com", "Jovana", false, "Jovanic", "owner3", "123456789", 2 }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                column: "Jmbg",
                values: new object[]
                {
                    "1234567890123",
                    "4567890123456"
                });

            migrationBuilder.InsertData(
                table: "Guest",
                column: "Jmbg",
                values: new object[]
                {
                    "1111111111111",
                    "2222222222222",
                    "3333333333333"
                });

            migrationBuilder.InsertData(
                table: "Owner",
                column: "Jmbg",
                values: new object[]
                {
                    "4444444444444",
                    "5555555555555",
                    "6666666666666"
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "ConstructionYear", "Name", "OwnerJmbg", "Rating", "Status" },
                values: new object[,]
                {
                    { 1, 2000, "Deluxe Hotel", "4444444444444", 5, 1 },
                    { 2, 1995, "Hotel Moscow", "4444444444444", 4, 1 },
                    { 3, 1990, "Hotel Paradise", "5555555555555", 3, 1 },
                    { 4, 1980, "Hotel Belgrade", "4444444444444", 4, 1 },
                    { 5, 1960, "Yugoslavia", "5555555555555", 3, 1 },
                    { 6, 2005, "Hotel Sheraton", "4444444444444", 5, 1 },
                    { 7, 1990, "Hilton", "4444444444444", 5, 0 },
                    { 8, 1990, "Hotel Vojvodina", "4444444444444", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Apartment",
                columns: new[] { "Id", "Description", "HotelId", "MaxGuestNumber", "Name", "RoomCount" },
                values: new object[,]
                {
                    { 1, "This is a sample description for apartment 1.", 1, 4, "Sample Apartment 1", 2 },
                    { 2, "This is a sample description for apartment 2.", 1, 6, "Sample Apartment 2", 3 },
                    { 3, "This is a sample description for apartment 3.", 2, 2, "Sample Apartment 3", 1 },
                    { 4, "This is a sample description for apartment 4.", 2, 8, "Sample Apartment 4", 4 },
                    { 5, "This is a sample description for apartment 5.", 3, 2, "Sample Apartment 5", 1 },
                    { 6, "This is a sample description for apartment 6.", 3, 4, "Sample Apartment 6", 2 },
                    { 7, "This is a sample description for apartment 7.", 1, 4, "Sample Apartment 7", 2 },
                    { 8, "This is a sample description for apartment 8.", 3, 4, "Sample Apartment 8", 2 }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "Id", "ApartmentId", "GuestJmbg", "RejectionReason", "ReservationDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, "1111111111111", "", new DateTime(2024, 1, 12, 11, 9, 19, 53, DateTimeKind.Local).AddTicks(3092), 0 },
                    { 2, 2, "2222222222222", "", new DateTime(2024, 1, 12, 11, 9, 19, 53, DateTimeKind.Local).AddTicks(3131), 0 },
                    { 3, 3, "1111111111111", "", new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 2, "2222222222222", "", new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 5, 1, "2222222222222", "", new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_HotelId",
                table: "Apartment",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_Name",
                table: "Apartment",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_OwnerJmbg",
                table: "Hotel",
                column: "OwnerJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ApartmentId",
                table: "Reservation",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_GuestJmbg",
                table: "Reservation",
                column: "GuestJmbg");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Apartment");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
