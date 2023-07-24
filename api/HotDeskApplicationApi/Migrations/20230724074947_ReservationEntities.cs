using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class ReservationEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Profile",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Profile",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Profile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Profile",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Profile",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FloorID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    OfficeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.ID);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Profile",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Profile",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
