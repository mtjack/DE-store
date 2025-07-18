using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DE_Store_Backend.Migrations
{
    /// <inheritdoc />
    public partial class freshmigrationsdir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StoreName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerName = table.Column<string>(type: "TEXT", nullable: false),
                    LoyaltyCard = table.Column<bool>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProductPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    DiscountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    userRole = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    PurchaseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PurchaseTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StoreId = table.Column<int>(type: "INTEGER", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.PurchaseId);
                    table.ForeignKey(
                        name: "FK_Purchases_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "DiscountType" },
                values: new object[,]
                {
                    { 1, "Buy one get one free" },
                    { 2, "3 for 2" },
                    { 3, "None" },
                    { 4, "10% off" },
                    { 5, "Clearance" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "StoreId", "StoreName" },
                values: new object[,]
                {
                    { 1, "Egg Factory" },
                    { 2, "Egg Factory Backup" },
                    { 3, "Egg Factory Outlet" },
                    { 4, "Downtown Egg Mart" },
                    { 5, "Suburban Egg Depot" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerName", "LoyaltyCard", "StoreId" },
                values: new object[,]
                {
                    { 1, "Skye Johnson", false, 1 },
                    { 2, "Matthew Smith", true, 1 },
                    { 3, "Olivia Brown", false, 1 },
                    { 4, "Liam Johnson", true, 2 },
                    { 5, "Ava Williams", true, 2 },
                    { 6, "Noah Miller", false, 3 },
                    { 7, "Emma Davis", false, 3 },
                    { 8, "Sophia Wilson", true, 4 },
                    { 9, "James Anderson", true, 4 },
                    { 10, "Isabella Thomas", false, 4 },
                    { 11, "Mason Moore", true, 5 },
                    { 12, "Ethan Taylor", false, 5 },
                    { 13, "Mia Jackson", true, 5 },
                    { 14, "Charlotte Harris", true, 1 },
                    { 15, "Henry Clark", false, 2 },
                    { 16, "Alexander Lewis", true, 3 },
                    { 17, "Amelia King", false, 4 },
                    { 18, "Daniel Scott", true, 5 },
                    { 19, "Lucas Young", false, 1 },
                    { 20, "Zoe Turner", true, 2 },
                    { 21, "Ella Roberts", false, 1 },
                    { 22, "William Carter", true, 2 },
                    { 23, "Avery Martin", false, 3 },
                    { 24, "Logan Walker", true, 4 },
                    { 25, "Grace Hill", true, 5 },
                    { 26, "Lily Green", false, 1 },
                    { 27, "Hannah Adams", true, 2 },
                    { 28, "Jack Nelson", false, 3 },
                    { 29, "Victoria Baker", true, 4 },
                    { 30, "Leo Perez", true, 5 },
                    { 31, "Isabella Rivera", false, 1 },
                    { 32, "David Brooks", true, 2 },
                    { 33, "Mason Long", false, 3 },
                    { 34, "Samantha Hughes", true, 4 },
                    { 35, "Gabriel Murphy", false, 5 },
                    { 36, "Abigail Simmons", true, 1 },
                    { 37, "Harper Foster", false, 2 },
                    { 38, "Oliver Gonzales", true, 3 },
                    { 39, "Zoey Bryant", false, 4 },
                    { 40, "Scarlett Barnes", true, 5 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "DiscountId", "ProductDescription", "ProductName", "ProductPrice", "Stock", "StoreId" },
                values: new object[,]
                {
                    { 1, 3, "Fresh egg", "Egg", 12, 100, 1 },
                    { 2, 4, "Chocolate egg", "Easter Egg", 20, 50, 1 },
                    { 3, 1, "Luxury egg with gold leaf", "Golden Egg", 50, 10, 1 },
                    { 4, 2, "Organic, free-range egg", "Organic Egg", 15, 75, 2 },
                    { 5, 3, "Carton of 12 eggs", "Egg Carton", 120, 30, 2 },
                    { 6, 5, "Decorative painted egg", "Painted Egg", 30, 25, 3 },
                    { 7, 3, "Small and delicate", "Quail Egg", 25, 200, 4 },
                    { 8, 2, "Rich and creamy", "Duck Egg", 18, 60, 4 },
                    { 9, 4, "Large and exotic", "Ostrich Egg", 150, 5, 5 },
                    { 10, 1, "Luxurious and rare", "Caviar Egg", 300, 8, 5 },
                    { 11, 5, "Preserved delicacy", "Century Egg", 45, 40, 3 },
                    { 12, 3, "Exotic delicacy", "Balut", 35, 70, 2 },
                    { 13, 4, "Festive beverage", "Egg Nog", 60, 90, 1 },
                    { 14, 2, "Health supplement", "Egg White Protein", 80, 120, 5 },
                    { 15, 4, "Spicy egg treat", "Deviled Egg", 25, 55, 1 },
                    { 16, 3, "Classic egg salad", "Egg Salad", 50, 85, 2 },
                    { 17, 5, "Egg wrapped in sausage", "Scotch Egg", 40, 35, 3 },
                    { 18, 2, "Sweet egg pastry", "Egg Tart", 30, 100, 4 },
                    { 19, 1, "Preserved salty egg", "Salted Egg", 20, 45, 5 },
                    { 20, 3, "Warm egg soup", "Egg Drop Soup", 35, 110, 4 },
                    { 21, 4, "Seasonal eggnog flavored latte", "Eggnog Latte", 45, 95, 1 },
                    { 22, 2, "Crispy egg rolls with filling", "Egg Rolls", 30, 130, 2 },
                    { 23, 1, "Light and fluffy egg mousse", "Egg Mousse", 55, 40, 3 },
                    { 24, 3, "Creamy egg pudding", "Egg Pudding", 40, 75, 4 },
                    { 25, 5, "Egg sandwich on whole grain bread", "Egg Sandwich", 35, 65, 5 },
                    { 26, 2, "Tacos filled with scrambled eggs", "Egg Tacos", 60, 50, 1 },
                    { 27, 4, "Poached eggs on English muffin", "Egg Benedict", 70, 20, 2 },
                    { 28, 3, "Sweet and smooth egg custard", "Egg Custard", 50, 55, 3 },
                    { 29, 1, "Egg and cheese muffin", "Egg Muffin", 45, 90, 4 },
                    { 30, 5, "Traditional egg drop soup", "Egg Soup", 25, 70, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "PasswordHash", "StoreId", "Username", "userRole" },
                values: new object[,]
                {
                    { 1, "Skye", "Jack", "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", 1, "Skye1357", "Admin" },
                    { 2, "Matthew", "Jack", "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", 2, "Mtjack1", "Manager" },
                    { 3, "John", "Doe", "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", 3, "JD123", "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "PurchaseId", "CustomerId", "ProductId", "PurchaseTime", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, 2, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, 3, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 4, 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 5, 5, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 6, 6, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 7, 11, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, 8, 7, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, 9, 8, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 10, 10, 9, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, 11, 10, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 12, 12, 14, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 13, 13, 12, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 14, 1, 13, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 15, 2, 4, new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 16, 3, 5, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 17, 4, 6, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 18, 5, 1, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 19, 6, 7, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 20, 7, 8, new DateTime(2024, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 21, 8, 9, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 22, 9, 10, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 23, 10, 11, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 24, 11, 12, new DateTime(2024, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 25, 12, 13, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 26, 13, 14, new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 27, 14, 15, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 28, 15, 16, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 29, 16, 17, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 30, 17, 18, new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 31, 18, 19, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 32, 19, 20, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 33, 20, 15, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 34, 21, 1, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 22, 2, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 36, 23, 3, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 37, 24, 4, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 38, 25, 5, new DateTime(2024, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 39, 26, 6, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 40, 27, 7, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 41, 28, 8, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 42, 29, 9, new DateTime(2024, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 43, 30, 10, new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 44, 31, 11, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 45, 32, 12, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 46, 33, 13, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 47, 34, 14, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 48, 35, 15, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 49, 36, 16, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, 37, 17, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 51, 38, 18, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 52, 39, 19, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 53, 40, 20, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 54, 21, 21, new DateTime(2024, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 55, 22, 22, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 56, 23, 23, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 57, 24, 24, new DateTime(2024, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 58, 25, 25, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 59, 26, 26, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 60, 27, 27, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 61, 28, 28, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 62, 29, 29, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 63, 30, 30, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 64, 31, 21, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, 32, 22, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 66, 33, 23, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 67, 34, 24, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 68, 35, 25, new DateTime(2024, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 69, 36, 26, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 70, 37, 27, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 71, 38, 28, new DateTime(2024, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 72, 39, 29, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 73, 40, 30, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 74, 21, 22, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 75, 22, 23, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 76, 23, 24, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 77, 24, 25, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 78, 25, 26, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 79, 26, 27, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 80, 27, 28, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreId",
                table: "Customers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_StoreId",
                table: "Purchases",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoreId",
                table: "Users",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
