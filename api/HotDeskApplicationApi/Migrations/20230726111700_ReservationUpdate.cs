using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "Reservations");


            migrationBuilder.CreateTable(
               name: "Reservations",
               columns: table => new
               {
                   ID = table.Column<Guid>(type: "uuid", nullable: false),
                   ProfileID = table.Column<Guid>(type: "uuid", nullable: false),
                   ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                   LeavingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                   OfficeID = table.Column<Guid>(type: "uuid", nullable: false),
                   FloorID = table.Column<Guid>(type: "uuid", nullable: false),
                   DeskID = table.Column<Guid>(type: "uuid", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Reservations", x => x.ID);
               });

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ProfileEmail",
                table: "Reservations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Profile");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Avatar",
                table: "Profile",
                type: "bytea", 
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
