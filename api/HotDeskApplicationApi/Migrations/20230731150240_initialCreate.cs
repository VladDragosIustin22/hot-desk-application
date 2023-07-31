using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotDeskApplicationApi.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
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
                    FloorID = table.Column<Guid>(type: "uuid", nullable: false),
                    OfficeID = table.Column<Guid>(type: "uuid", nullable: false)
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
                    Avatar = table.Column<byte[]>(type: "bytea", nullable: true),
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
                    ProfileEmail = table.Column<string>(type: "text", nullable: false),
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
                columns: new[] { "ID", "FloorID", "Name", "OfficeID" },
                values: new object[,]
                {
                    { new Guid("2264edff-53ee-40dc-99d4-fbf19af30993"), new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "PP3", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("2803fdf2-9f05-4fa5-86e1-7605893f6dd5"), new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "PP1", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("2de9491c-be24-4a14-beef-794eaaa03473"), new Guid("b417af8e-66e0-4f83-9f94-cbf06fe92824"), "PE12", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("43268651-56fb-47fb-9b42-43ed0d5a28cd"), new Guid("ef7df01f-276d-4b64-ad3a-87fdcaaa7b24"), "BE23", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("65ce6d9b-9c61-4cc3-965d-ce5ee6727c8b"), new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "PP4", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("6630a06e-0b86-472e-8384-580144d2a06a"), new Guid("b417af8e-66e0-4f83-9f94-cbf06fe92824"), "PE14", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("7474e87e-fbb5-4186-902d-64f223316ea2"), new Guid("b417af8e-66e0-4f83-9f94-cbf06fe92824"), "PE13", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("7661a08b-b64a-4587-8f69-cf18903ff4be"), new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "PP5", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("893c7450-576b-4e75-b89c-aa8f2b55f360"), new Guid("ef7df01f-276d-4b64-ad3a-87fdcaaa7b24"), "BE21", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("96fa07a0-adf0-48ea-a2eb-01d5d34b0284"), new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "PP2", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("b3222f2b-1454-4a06-880c-11f464a8bdca"), new Guid("da3e4963-e5c6-4db1-b0cd-a93f21154cd0"), "PE22", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("b884a355-0968-440f-a15e-b617a3df61f4"), new Guid("b417af8e-66e0-4f83-9f94-cbf06fe92824"), "PE11", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("b9469428-42b3-42f6-911b-8e7eb28fe8aa"), new Guid("da3e4963-e5c6-4db1-b0cd-a93f21154cd0"), "PE21", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("cab137b2-5385-4b05-adc7-5c56c9d16076"), new Guid("ef7df01f-276d-4b64-ad3a-87fdcaaa7b24"), "BE24", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("dadd6897-4a03-463a-8bcd-3f04d30e4630"), new Guid("ef7df01f-276d-4b64-ad3a-87fdcaaa7b24"), "BE22", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("e3625eaa-eefb-4a97-885a-194d18ce91e1"), new Guid("da3e4963-e5c6-4db1-b0cd-a93f21154cd0"), "PE24", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("fb45eca2-53f7-4caa-b811-658fbf1b4be2"), new Guid("ffe7527f-b3c3-480f-8c50-6538fbf832ed"), "BE13", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("fc8f5007-277c-4836-a7f5-ef88b0028de6"), new Guid("ffe7527f-b3c3-480f-8c50-6538fbf832ed"), "BE14", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("fda0778f-3b18-42e8-a2c5-f597118a8020"), new Guid("da3e4963-e5c6-4db1-b0cd-a93f21154cd0"), "PE23", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "ID", "Name", "OfficeID" },
                values: new object[,]
                {
                    { new Guid("2a965ccf-1862-4cb7-9731-c376bf299611"), "Ground Floor", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("b417af8e-66e0-4f83-9f94-cbf06fe92824"), "Floor 1", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("da3e4963-e5c6-4db1-b0cd-a93f21154cd0"), "Floor 2", new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546") },
                    { new Guid("ef7df01f-276d-4b64-ad3a-87fdcaaa7b24"), "Floor 2", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") },
                    { new Guid("ffe7527f-b3c3-480f-8c50-6538fbf832ed"), "Floor 1", new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9") }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("49a001b2-5cd5-41c8-b640-a77d2e17f546"), "Predeal" },
                    { new Guid("e9d74e64-823f-4eb8-a9fb-18bc59a8e5e9"), "Brizei" }
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
