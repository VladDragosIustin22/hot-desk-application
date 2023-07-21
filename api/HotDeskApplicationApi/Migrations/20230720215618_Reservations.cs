using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class Reservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Floors_FloorID",
                table: "Desks");

            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors");

            migrationBuilder.DropIndex(
                name: "IX_Floors_OfficeID",
                table: "Floors");

            migrationBuilder.DropIndex(
                name: "IX_Desks_FloorID",
                table: "Desks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Floors_OfficeID",
                table: "Floors",
                column: "OfficeID");

            migrationBuilder.CreateIndex(
                name: "IX_Desks_FloorID",
                table: "Desks",
                column: "FloorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Floors_FloorID",
                table: "Desks",
                column: "FloorID",
                principalTable: "Floors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Offices_OfficeID",
                table: "Floors",
                column: "OfficeID",
                principalTable: "Offices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
