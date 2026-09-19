using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Event_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_AttendeeId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Organizers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "karim.ibrahim@example.com", "Karim Ibrahim", "+201301234567" },
                    { 2, "layla.ahmad@example.com", "Layla Ahmad", "+201401234567" },
                    { 3, "omar.khaled@example.com", "Omar Khaled", "+201501234567" },
                    { 4, "noor.hassan@example.com", "Noor Hassan", "+201601234567" },
                    { 5, "salma.sayed@example.com", "Salma Sayed", "+201701234567" },
                    { 6, "hassan.amin@example.com", "Hassan Amin", "+201801234567" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "Email", "FullName", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed.mohamed@example.com", "Ahmed Mohamed", "+201001234567" },
                    { 2, "fatima.hassan@example.com", "Fatima Hassan", "+201101234567" },
                    { 3, "mohammed.ali@example.com", "Mohammed Ali", "+201201234567" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Capacity", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 5000, "Cairo, Egypt", "Grand Convention Center" },
                    { 2, 2000, "Alexandria, Egypt", "Marina Event Hall" },
                    { 3, 3000, "Giza, Egypt", "Giza Exhibition Complex" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Capacity", "Category", "Description", "EndTime", "EventDate", "OrganizerId", "StartTime", "Title", "VenueId" },
                values: new object[,]
                {
                    { 1, 1000, "Technology", "Annual technology conference featuring latest innovations in AI and cloud computing", new TimeSpan(0, 17, 0, 0, 0), new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 9, 0, 0, 0), "Tech Conference 2025", 1 },
                    { 2, 500, "Business", "Exclusive networking event for business professionals and entrepreneurs", new TimeSpan(0, 18, 0, 0, 0), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 10, 0, 0, 0), "Business Networking Summit", 2 },
                    { 3, 300, "Marketing", "Intensive workshop on modern digital marketing strategies and tools", new TimeSpan(0, 16, 30, 0, 0), new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new TimeSpan(0, 8, 30, 0, 0), "Digital Marketing Workshop", 3 },
                    { 4, 200, "Training", "Comprehensive leadership training for mid-level and senior management", new TimeSpan(0, 17, 30, 0, 0), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new TimeSpan(0, 9, 30, 0, 0), "Leadership Development Program", 1 },
                    { 5, 400, "Technology", "48-hour hackathon for developers and innovators to build solutions", new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new TimeSpan(0, 8, 0, 0, 0), "Innovation Hackathon", 2 }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "Id", "AttendeeId", "EventId", "RegistrationDate", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 2, 2, 1, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 3, 3, 2, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 4, 4, 2, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 5, 5, 3, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 6, 1, 4, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 7, 2, 5, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" },
                    { 8, 6, 5, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Confirmed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Venues_Name",
                table: "Venues",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeId_EventId",
                table: "Registrations",
                columns: new[] { "AttendeeId", "EventId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId_AttendeeId",
                table: "Registrations",
                columns: new[] { "EventId", "AttendeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_Email",
                table: "Organizers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_Email",
                table: "Attendees",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venues_Name",
                table: "Venues");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_AttendeeId_EventId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_EventId_AttendeeId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_Email",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_Email",
                table: "Attendees");

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Registrations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organizers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Venues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Phone",
                table: "Organizers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_AttendeeId",
                table: "Registrations",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_EventId",
                table: "Registrations",
                column: "EventId");
        }
    }
}
