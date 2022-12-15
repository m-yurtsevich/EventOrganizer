using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventOrganizer.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventModels",
                columns: new[] { "Id", "Description", "Discriminator", "EndDate", "EndTime", "MeetingLink", "OwnerId", "StartDate", "StartTime", "Title" },
                values: new object[] { 1, "Mastery completion and presentation of the final product", "OnlineEvent", new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 19, 0, 0, 0), null, null, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 18, 0, 0, 0), "Event organizer presentation" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventModels",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
