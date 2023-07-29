using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Profile",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ID);
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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Desks",
                columns: new[] { "ID", "FloorID", "Name" },
                values: new object[,]
                {
                    { new Guid("098b1240-a79f-4d15-88fe-ea86ffb7fb38"), new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "PP5" },
                    { new Guid("0d031233-488d-42f3-bc5a-5b4b0e31d959"), new Guid("57b3201b-0fe4-4b5b-8544-e5044173ed2a"), "BE13" },
                    { new Guid("10f4ee17-a519-49f3-b77e-4e94fdd462ee"), new Guid("adc20ba6-0036-4fd6-83ca-7d620e98f9bd"), "PE24" },
                    { new Guid("2129adbd-ccc5-49f6-b3ae-2a51caaf325b"), new Guid("c3cd5ef0-6a31-4f41-b865-4af13ba23ee3"), "PE11" },
                    { new Guid("381bd954-be9e-4ad2-9868-d5a12625e8ab"), new Guid("6ff878bc-c827-4d9e-b892-bde6ebf3a55d"), "BE23" },
                    { new Guid("388cf175-973f-4ed0-8e57-cc169156ed90"), new Guid("adc20ba6-0036-4fd6-83ca-7d620e98f9bd"), "PE22" },
                    { new Guid("5d857fa8-b520-4dc7-b9cf-bf3e825b8275"), new Guid("6ff878bc-c827-4d9e-b892-bde6ebf3a55d"), "BE22" },
                    { new Guid("67c0077b-388a-4b7f-b1ff-f7eeceaefcf6"), new Guid("adc20ba6-0036-4fd6-83ca-7d620e98f9bd"), "PE23" },
                    { new Guid("6ee58175-299f-41ed-8b8f-045fc52b8838"), new Guid("c3cd5ef0-6a31-4f41-b865-4af13ba23ee3"), "PE14" },
                    { new Guid("7bad3dd6-41b6-42f9-82a0-59e00f12e25a"), new Guid("57b3201b-0fe4-4b5b-8544-e5044173ed2a"), "BE14" },
                    { new Guid("7f8b59bf-ac5a-4040-b5e5-9eda3fb2a479"), new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "PP4" },
                    { new Guid("ab3765a1-dde6-44ba-97a2-cf9a9a8e79a9"), new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "PP2" },
                    { new Guid("c66fe525-fd35-4edd-9b20-5aa45eff8b01"), new Guid("6ff878bc-c827-4d9e-b892-bde6ebf3a55d"), "BE24" },
                    { new Guid("c9a1288c-9e3c-42e8-98fa-e78cfd57cad3"), new Guid("c3cd5ef0-6a31-4f41-b865-4af13ba23ee3"), "PE12" },
                    { new Guid("d43023e1-b793-4999-949d-1ee7fc9258e2"), new Guid("6ff878bc-c827-4d9e-b892-bde6ebf3a55d"), "BE21" },
                    { new Guid("e2b2a7fa-b035-456d-a327-1812145f734b"), new Guid("adc20ba6-0036-4fd6-83ca-7d620e98f9bd"), "PE21" },
                    { new Guid("e45b99b5-c5b9-4efe-8c35-9a79d4e3b72d"), new Guid("c3cd5ef0-6a31-4f41-b865-4af13ba23ee3"), "PE13" },
                    { new Guid("f1890e2c-9f87-49f2-9358-4fc8473f6859"), new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "PP1" },
                    { new Guid("f7bcc4f7-8b8e-4d34-aca4-ca0fdd4b7348"), new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "PP3" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "ID", "Name", "OfficeID" },
                values: new object[,]
                {
                    { new Guid("57b3201b-0fe4-4b5b-8544-e5044173ed2a"), "Floor 1", new Guid("21e7299d-6887-4585-8550-cc5c9961b397") },
                    { new Guid("6ff878bc-c827-4d9e-b892-bde6ebf3a55d"), "Floor 2", new Guid("21e7299d-6887-4585-8550-cc5c9961b397") },
                    { new Guid("944e1316-5d1d-4a82-9148-3805252af5c3"), "Ground Floor", new Guid("633fab52-a103-44a2-abf7-3639249d61fd") },
                    { new Guid("adc20ba6-0036-4fd6-83ca-7d620e98f9bd"), "Floor 2", new Guid("633fab52-a103-44a2-abf7-3639249d61fd") },
                    { new Guid("c3cd5ef0-6a31-4f41-b865-4af13ba23ee3"), "Floor 1", new Guid("633fab52-a103-44a2-abf7-3639249d61fd") }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("21e7299d-6887-4585-8550-cc5c9961b397"), "Brizei" },
                    { new Guid("633fab52-a103-44a2-abf7-3639249d61fd"), "Predeal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Desks");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
