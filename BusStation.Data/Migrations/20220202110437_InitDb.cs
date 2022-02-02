using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BusStation.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusStops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDayes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDayes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Nodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinutesInWay = table.Column<int>(type: "int", nullable: false),
                    WaitingTime = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    FirstBusStopId = table.Column<int>(type: "int", nullable: false),
                    SecondBusStopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodes_BusStops_FirstBusStopId",
                        column: x => x.FirstBusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nodes_BusStops_SecondBusStopId",
                        column: x => x.SecondBusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_RouteTypes_RouteTypeId",
                        column: x => x.RouteTypeId,
                        principalTable: "RouteTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteNodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    NodeId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteNodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteNodes_Nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "Nodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteNodes_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: true),
                    IsBack = table.Column<bool>(type: "bit", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfMovementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_ScheduleDayes_DayOfMovementId",
                        column: x => x.DayOfMovementId,
                        principalTable: "ScheduleDayes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BusStops",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Novopolotsk", "Bus station" },
                    { 28, "Polotsk", "College of Economics" },
                    { 30, "Polotsk", "Pedagogical College" },
                    { 31, "Novopolotsk", "Sewing Factory" },
                    { 32, "Novopolotsk", "Printing house" },
                    { 33, "Novopolotsk", "Suvorov" },
                    { 34, "Novopolotsk", "Leningrad" },
                    { 35, "Novopolotsk", "Locomotive Depot" },
                    { 36, "Novopolotsk", "School №14" },
                    { 37, "Novopolotsk", "Move" },
                    { 38, "Novopolotsk", "Tchaikovsky" },
                    { 27, "Polotsk", "Sports Club" },
                    { 39, "Novopolotsk", "Griboyedov" },
                    { 41, "Novopolotsk", "Kalinina" },
                    { 42, "Polotsl", "Manege" },
                    { 43, "Novopolotsk", "Soyuzpechat" },
                    { 44, "Polotsk", "Fire Station" },
                    { 45, "Polotsk", "Matrosova" },
                    { 46, "Polotsk", "School №18" },
                    { 47, "Polotsk", "Masherova" },
                    { 48, "Polotsk", "Partisan" },
                    { 49, "Polotsk", "Fleet" },
                    { 50, "Novopolotsk", "Nevelskaya" },
                    { 40, "Novopolotsk", "Bagramyan" },
                    { 26, "Polotsk", "Power supply" },
                    { 29, "Novopolotsk", "Hotel Belarus" },
                    { 24, "Polotsk", "Ekiman" },
                    { 2, "Novopolotsk", "Shopping centre" },
                    { 3, "Novopolotsk", "Slobodskaya" },
                    { 4, "Novopolotsk", "Gaidara" },
                    { 5, "Novopolotsk", "The First Tent" },
                    { 6, "Novopolotsk", "Golden Field" },
                    { 7, "Novopolotsk", "Cosmos Cinema" },
                    { 8, "Novopolotsk", "Youth" },
                    { 9, "Novopolotsk", "Komsomolskaya" },
                    { 25, "Polotsk", "Zapolotye" },
                    { 11, "Novopolotsk", "Cinema Minsk" },
                    { 12, "Novopolotsk", "Naftan Hotel" },
                    { 10, "Novopolotsk", "Music School" },
                    { 14, "Novopolotsk", "Podcastels" },
                    { 15, "Novopolotsk", "Vasilevtsy" },
                    { 16, "Novopolotsk", "8th Microdistrict" }
                });

            migrationBuilder.InsertData(
                table: "BusStops",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 17, "Novopolotsk", "Polimirovskaya" },
                    { 18, "Novopolotsk", "Solar" },
                    { 19, "Novopolotsk", "Meadow" },
                    { 20, "Novopolotsk", "Ekiman-1" },
                    { 21, "Novopolotsk", "Ekiman-2" },
                    { 22, "Polotsk", "Ksta Hospital" },
                    { 13, "Novopolotsk", "Factory Meter" },
                    { 23, "Polotsk", "The Mound of Immortality" }
                });

            migrationBuilder.InsertData(
                table: "RouteTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Intercity" },
                    { 2, "Suburban" },
                    { 3, "Urban" }
                });

            migrationBuilder.InsertData(
                table: "ScheduleDayes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Everyday" },
                    { 4, "Weekend" },
                    { 1, "Even days" },
                    { 2, "Odd days" },
                    { 5, "Weekdays" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusStops_Name",
                table: "BusStops",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_FirstBusStopId",
                table: "Nodes",
                column: "FirstBusStopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_SecondBusStopId",
                table: "Nodes",
                column: "SecondBusStopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteNodes_NodeId",
                table: "RouteNodes",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteNodes_RouteId",
                table: "RouteNodes",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DayOfMovementId",
                table: "Trips",
                column: "DayOfMovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteId",
                table: "Trips",
                column: "RouteId");
        }

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
                name: "RouteNodes");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Nodes");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "ScheduleDayes");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "RouteTypes");
        }
    }
}
