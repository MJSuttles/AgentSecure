using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AgentSecure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CatName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    Zip = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    LoginWebsite = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Consortium = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegApproved = table.Column<bool>(type: "boolean", nullable: false),
                    TrainingComplete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logins_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VendorCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendorId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendorCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendorCategories_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CatName" },
                values: new object[,]
                {
                    { 1, "Theme Park" },
                    { 2, "Cruise" },
                    { 3, "Tour Operator" },
                    { 4, "Luxury Travel" },
                    { 5, "All-Inclusive" },
                    { 6, "Reseller" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "Email", "FirstName", "LastName", "Phone", "State", "StreetAddress", "Uid", "Zip" },
                values: new object[,]
                {
                    { 1, "Nashville", "alice.johnson@example.com", "Alice", "Johnson", "555-123-4567", "TN", "123 Elm Street", "-Nabc123XYZ7890user1", "37201" },
                    { 2, "Atlanta", "bob.martinez@example.com", "Bob", "Martinez", "555-987-6543", "GA", "456 Oak Avenue", "-Ndef456LMN4567user2", "30301" }
                });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "Id", "Consortium", "Description", "LoginWebsite", "Name", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "", "Luxury river and ocean cruise line known for cultural experiences.", "https://www.vikingtravelagents.com", "Viking Cruises", "800-706-1483", "https://www.vikingcruises.com" },
                    { 2, "VAX Vacation Access", "Air and hotel vacation packages powered by Delta Air Lines.", "www.vaxvacationaccess.com", "Delta Vacations", "800-727-1111", "https://www.delta.com/vacations" },
                    { 3, "", "All-inclusive Caribbean resorts for couples.", "https://taportal.sandals.com", "Sandals Resorts", "888-726-3257", "https://www.sandals.com" },
                    { 4, "", "Booking site and resources for Disney Destinations travel professionals.", "https://www.disneytravelagents.com", "Disney Travel Agents", "877-569-3276", "https://www.disneytravelagents.com" },
                    { 5, "Cruising Power", "Popular cruise line with innovative ships and global destinations.", "https://www.cruisingpower.com", "Royal Caribbean", "800-327-2056", "https://www.royalcaribbean.com" },
                    { 6, "", "Tour operator offering guided land tours and independent travel.", "https://www.globusfamily.com/TravelAgents", "Globus Family of Brands", "866-755-8581", "https://www.globusjourneys.com" },
                    { 7, "", "Luxury vacation wholesaler with access to top resorts worldwide.", "https://www.vaxvacationaccess.com", "Travel Impressions", "800-284-0044", "https://www.travelimpressions.com" },
                    { 8, "", "Travel agent affiliate program offering hotels, flights, and packages.", "https://www.expediataap.com", "Expedia TAAP", "866-310-5768", "https://www.expedia.com" },
                    { 9, "VAX Vacation Access", "U.S. tour operator known for beach vacations and charter flights.", "https://www.vaxvacationaccess.com", "Apple Vacations", "800-517-2000", "https://www.applevacations.com" },
                    { 10, "", "Collection of luxury resort brands in Mexico and the Caribbean.", "https://www.amragents.com", "AmResorts", "866-847-8184", "https://www.amrcollection.com" }
                });

            migrationBuilder.InsertData(
                table: "Logins",
                columns: new[] { "Id", "Email", "Password", "RegApproved", "TrainingComplete", "UserId", "Username", "VendorId" },
                values: new object[,]
                {
                    { 1, "alice.j@viking.com", "Pass123!", true, true, 1, "alice.viking", 1 },
                    { 2, "alice.s@sandals.com", "Tropic123!", true, false, 1, "alice.sandals", 3 },
                    { 3, "alice.r@royal.com", "CruiseIt!", false, false, 1, "alice.rccl", 5 },
                    { 4, "alice.a@applevacs.com", "BeachTime!", true, true, 1, "alice.apple", 9 },
                    { 5, "alice.d@disney.com", "Magic123!", true, true, 1, "alice.disney", 4 },
                    { 6, "bob.d@delta.com", "SkyHigh1!", true, false, 2, "bob.delta", 2 },
                    { 7, "bob.g@globus.com", "Tours2024!", false, false, 2, "bob.globus", 6 },
                    { 8, "bob.t@ti.com", "ResortLife!", true, true, 2, "bob.ti", 7 },
                    { 9, "bob.e@expedia.com", "EasyBook!", true, false, 2, "bob.expedia", 8 },
                    { 10, "bob.a@amr.com", "AMRsecure!", true, true, 2, "bob.amresorts", 10 }
                });

            migrationBuilder.InsertData(
                table: "VendorCategories",
                columns: new[] { "Id", "CategoryId", "VendorId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 3 },
                    { 5, 5, 3 },
                    { 6, 1, 4 },
                    { 7, 2, 5 },
                    { 8, 3, 6 },
                    { 9, 6, 7 },
                    { 10, 3, 7 },
                    { 11, 6, 8 },
                    { 12, 6, 9 },
                    { 13, 6, 10 },
                    { 14, 4, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Logins_VendorId",
                table: "Logins",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorCategories_CategoryId",
                table: "VendorCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VendorCategories_VendorId",
                table: "VendorCategories",
                column: "VendorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "VendorCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
