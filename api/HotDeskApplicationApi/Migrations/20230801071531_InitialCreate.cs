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
                    { new Guid("07acf76c-87e8-4db0-9bd9-c0a93ce5dc8c"), new Guid("55529eb0-d278-4681-80fe-41c7e738d7a5"), "BE13", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("0a05ed78-d5f4-4bb4-a100-ff85cc54b9f7"), new Guid("8d57830b-0090-4b5b-aeea-a72197d8a250"), "PE24", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("2704c4eb-dffa-4c34-9908-efa5c003ac8d"), new Guid("85f71447-fddc-4dc3-acdf-2c4c15de0a19"), "BE22", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("293d81c0-b316-4fde-8ba4-aeb71725c9d8"), new Guid("8d57830b-0090-4b5b-aeea-a72197d8a250"), "PE21", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("3393eb3c-7a39-4da9-91cc-23efdfc2b27c"), new Guid("8d57830b-0090-4b5b-aeea-a72197d8a250"), "PE22", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("3f2f7b67-5cce-4338-8a52-2d33210ac4f2"), new Guid("8d57830b-0090-4b5b-aeea-a72197d8a250"), "PE23", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("4dc84b09-95fd-4f90-9025-2255712f31f2"), new Guid("6da51987-fee8-4804-98fd-6945051172bd"), "PE13", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("5b433aec-54ea-4e04-9447-4d65c47f4bf8"), new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "PP1", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("61a6a913-df3b-454c-9dde-230b60ea058c"), new Guid("6da51987-fee8-4804-98fd-6945051172bd"), "PE12", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("6307efad-0ea0-4342-99d4-402d67180319"), new Guid("55529eb0-d278-4681-80fe-41c7e738d7a5"), "BE14", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("72ae4345-2cde-4e22-a09d-944499f47163"), new Guid("6da51987-fee8-4804-98fd-6945051172bd"), "PE11", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("85b363a3-c052-4ba2-a466-0e9f6d485248"), new Guid("85f71447-fddc-4dc3-acdf-2c4c15de0a19"), "BE21", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("8ff579a9-1016-4ee0-8ae9-3fe6915e0a48"), new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "PP5", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("926c8afd-ee70-4372-add5-6320ab116f5f"), new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "PP2", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("9395c4b8-ca8a-4e74-a725-5ffc4c50c12e"), new Guid("85f71447-fddc-4dc3-acdf-2c4c15de0a19"), "BE23", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("a220de6a-f999-45a4-ae28-a503aa49f9ea"), new Guid("85f71447-fddc-4dc3-acdf-2c4c15de0a19"), "BE24", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("bac4da7a-2b44-4ff1-b37e-bc62e4791462"), new Guid("6da51987-fee8-4804-98fd-6945051172bd"), "PE14", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("d70df64b-6e1a-4b69-8cdb-df279c48b2b7"), new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "PP4", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("df83c7c0-c202-4d9e-8005-cb3296439781"), new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "PP3", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "ID", "Name", "OfficeID" },
                values: new object[,]
                {
                    { new Guid("37bb197b-7d02-4c81-a4b1-fce0e4d06f83"), "Ground Floor", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("55529eb0-d278-4681-80fe-41c7e738d7a5"), "Floor 1", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("6da51987-fee8-4804-98fd-6945051172bd"), "Floor 1", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") },
                    { new Guid("85f71447-fddc-4dc3-acdf-2c4c15de0a19"), "Floor 2", new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e") },
                    { new Guid("8d57830b-0090-4b5b-aeea-a72197d8a250"), "Floor 2", new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5") }
                });

            migrationBuilder.InsertData(
                table: "Offices",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("006e9d57-99d2-40b2-b0e1-db7197b226d5"), "Predeal" },
                    { new Guid("dd02e05a-449d-4438-b84a-2cdee7b5069e"), "Brizei" }
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
