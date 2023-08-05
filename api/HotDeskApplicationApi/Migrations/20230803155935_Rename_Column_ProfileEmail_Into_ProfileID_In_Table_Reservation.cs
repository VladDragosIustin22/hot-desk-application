using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Column_ProfileEmail_Into_ProfileID_In_Table_Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileEmail",
                table: "Reservations");

            migrationBuilder.AddColumn<Guid>(
                name: "ProfileID",
                table: "Reservations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ProfileEmail",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
