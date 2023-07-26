using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class ReservationUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Profile");

            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Profile",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "Profile",
                type: "text",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
