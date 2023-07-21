using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
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
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LeavingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfileID = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeID = table.Column<Guid>(type: "uuid", nullable: false),
                    FloorID = table.Column<Guid>(type: "uuid", nullable: false),
                    DeskID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    OfficeID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Floors_Offices_OfficeID",
                        column: x => x.OfficeID,
                        principalTable: "Offices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Desks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    FloorID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Desks_Floors_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Floors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desks_FloorID",
                table: "Desks",
                column: "FloorID");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_OfficeID",
                table: "Floors",
                column: "OfficeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
