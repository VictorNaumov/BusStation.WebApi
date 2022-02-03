using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BusStation.Data.Migrations
{
    public partial class InitDB : Migration
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
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Driver = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
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
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
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
                name: "RouteBusStop",
                columns: table => new
                {
                    Order = table.Column<int>(type: "int", nullable: false),
                    BusStopId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    MinutesInWay = table.Column<int>(type: "int", nullable: false),
                    WaitingTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteBusStop", x => new { x.RouteId, x.BusStopId, x.Order });
                    table.ForeignKey(
                        name: "FK_RouteBusStop_BusStops_BusStopId",
                        column: x => x.BusStopId,
                        principalTable: "BusStops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteBusStop_Routes_RouteId",
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
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusStops",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 30, "Polotsk", "Pedagogical College" },
                    { 26, "Polotsk", "Power supply" },
                    { 27, "Polotsk", "Sports Club" },
                    { 28, "Polotsk", "College of Economics" },
                    { 29, "Novopolotsk", "Hotel Belarus" },
                    { 52, "Braslav", "Bus station" },
                    { 31, "Novopolotsk", "Sewing Factory" },
                    { 32, "Novopolotsk", "Printing house" },
                    { 33, "Novopolotsk", "Suvorov" },
                    { 34, "Novopolotsk", "Leningrad" },
                    { 35, "Novopolotsk", "Locomotive Depot" },
                    { 36, "Novopolotsk", "School №14" },
                    { 25, "Polotsk", "Zapolotye" },
                    { 37, "Novopolotsk", "Move" },
                    { 39, "Novopolotsk", "Griboyedov" },
                    { 40, "Novopolotsk", "Bagramyan" },
                    { 41, "Novopolotsk", "Kalinina" },
                    { 42, "Polotsl", "Manege" },
                    { 43, "Novopolotsk", "Soyuzpechat" },
                    { 44, "Polotsk", "Fire Station" },
                    { 45, "Polotsk", "Matrosova" },
                    { 46, "Polotsk", "School №18" },
                    { 47, "Polotsk", "Masherova" },
                    { 48, "Polotsk", "Partisan" },
                    { 49, "Polotsk", "Fleet" },
                    { 38, "Novopolotsk", "Tchaikovsky" },
                    { 24, "Polotsk", "Ekiman" },
                    { 23, "Polotsk", "The Mound of Immortality" },
                    { 22, "Polotsk", "Ksta Hospital" },
                    { 56, "Lida", "Bus station" },
                    { 55, "Grodno", "Bus station" },
                    { 54, "Brest", "Bus station" },
                    { 53, "Miory", "Bus station" },
                    { 1, "Novopolotsk", "Bus station" },
                    { 2, "Novopolotsk", "Shopping centre" },
                    { 3, "Novopolotsk", "Slobodskaya" },
                    { 4, "Novopolotsk", "Gaidara" },
                    { 5, "Novopolotsk", "The First Tent" },
                    { 6, "Novopolotsk", "Golden Field" },
                    { 7, "Novopolotsk", "Cosmos Cinema" },
                    { 8, "Novopolotsk", "Youth" },
                    { 9, "Novopolotsk", "Komsomolskaya" }
                });

            migrationBuilder.InsertData(
                table: "BusStops",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 10, "Novopolotsk", "Music School" },
                    { 11, "Novopolotsk", "Cinema Minsk" },
                    { 12, "Novopolotsk", "Naftan Hotel" },
                    { 13, "Novopolotsk", "Factory Meter" },
                    { 14, "Novopolotsk", "Podcastels" },
                    { 15, "Novopolotsk", "Vasilevtsy" },
                    { 16, "Novopolotsk", "8th Microdistrict" },
                    { 17, "Novopolotsk", "Polimirovskaya" },
                    { 18, "Novopolotsk", "Solar" },
                    { 19, "Novopolotsk", "Meadow" },
                    { 20, "Novopolotsk", "Ekiman-1" },
                    { 21, "Novopolotsk", "Ekiman-2" },
                    { 50, "Novopolotsk", "Nevelskaya" },
                    { 51, "Minsk", "Bus station" }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "CountOfSeats", "Driver", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 30, "Petrov Vanya", "Tesla Bus", "1363BM" },
                    { 5, 25, "Ignatiev Ignat", "BMW Bus", "7618BM" },
                    { 4, 50, "Novikov Evgene", "Audi Bus", "7426BM" },
                    { 3, 25, "Miller Anton", "Super Bus", "6184BM" },
                    { 2, 45, "Kokorin Ilya", "Transit Bus", "9123BM" }
                });

            migrationBuilder.InsertData(
                table: "RouteTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Urban" },
                    { 2, "Suburban" },
                    { 3, "Intercity" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Even days" },
                    { 2, "Odd days" },
                    { 3, "Everyday" },
                    { 4, "Weekend" },
                    { 5, "Weekdays" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "RouteTypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 3 },
                    { 6, 3 }
                });

            migrationBuilder.InsertData(
                table: "RouteBusStop",
                columns: new[] { "BusStopId", "Order", "RouteId", "MinutesInWay", "WaitingTime" },
                values: new object[,]
                {
                    { 1, 1, 1, 3, 0 },
                    { 54, 1, 6, 120, 30 },
                    { 52, 2, 5, 40, 10 },
                    { 53, 1, 5, 90, 10 },
                    { 43, 5, 4, 3, 0 },
                    { 42, 4, 4, 5, 0 },
                    { 41, 3, 4, 6, 0 },
                    { 44, 2, 4, 4, 0 },
                    { 46, 1, 4, 5, 0 },
                    { 19, 3, 3, 15, 0 },
                    { 36, 2, 3, 21, 0 },
                    { 31, 1, 3, 5, 0 },
                    { 55, 2, 6, 110, 30 },
                    { 56, 3, 6, 120, 30 },
                    { 23, 4, 2, 5, 0 },
                    { 17, 3, 2, 3, 0 },
                    { 7, 2, 2, 9, 0 },
                    { 1, 1, 2, 3, 0 },
                    { 12, 6, 1, 3, 0 },
                    { 11, 5, 1, 6, 0 },
                    { 3, 4, 1, 11, 0 },
                    { 6, 3, 1, 10, 0 },
                    { 4, 2, 1, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "BusId", "DepartureTime", "RouteId", "ScheduleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 2, 1, new DateTime(1, 1, 1, 18, 30, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 4, 2, new DateTime(1, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 3, 3, new DateTime(1, 1, 1, 14, 20, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 5, 1, new DateTime(1, 1, 1, 15, 25, 0, 0, DateTimeKind.Unspecified), 2, 4 }
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
                name: "IX_RouteBusStop_BusStopId",
                table: "RouteBusStop",
                column: "BusStopId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_RouteTypeId",
                table: "Routes",
                column: "RouteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BusId",
                table: "Trips",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_RouteId",
                table: "Trips",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ScheduleId",
                table: "Trips",
                column: "ScheduleId");
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
                name: "RouteBusStop");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BusStops");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "RouteTypes");
        }
    }
}
