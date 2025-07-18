using DE_Store_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace DE_Store_Backend.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    public string DbPath { get; }

    public ApplicationDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "DE-store.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Discounts
        modelBuilder.Entity<Discount>().HasData(
            new Discount { Id = 1, DiscountType = "Buy one get one free" },
            new Discount { Id = 2, DiscountType = "3 for 2" },
            new Discount { Id = 3, DiscountType = "None" },
            new Discount { Id = 4, DiscountType = "10% off" },
            new Discount { Id = 5, DiscountType = "Clearance" }
        );

        // Stores
        modelBuilder.Entity<Store>().HasData(
            new Store { StoreId = 1, StoreName = "Egg Factory" },
            new Store { StoreId = 2, StoreName = "Egg Factory Backup" },
            new Store { StoreId = 3, StoreName = "Egg Factory Outlet" },
            new Store { StoreId = 4, StoreName = "Downtown Egg Mart" },
            new Store { StoreId = 5, StoreName = "Suburban Egg Depot" }
        );

        // Products
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Egg", ProductDescription = "Fresh egg", ProductPrice = 12, DiscountId = 3, StoreId = 1, Stock = 100 },
            new Product { ProductId = 2, ProductName = "Easter Egg", ProductDescription = "Chocolate egg", ProductPrice = 20, DiscountId = 4, StoreId = 1, Stock = 50 },
            new Product { ProductId = 3, ProductName = "Golden Egg", ProductDescription = "Luxury egg with gold leaf", ProductPrice = 50, DiscountId = 1, StoreId = 1, Stock = 10 },
            new Product { ProductId = 4, ProductName = "Organic Egg", ProductDescription = "Organic, free-range egg", ProductPrice = 15, DiscountId = 2, StoreId = 2, Stock = 75 },
            new Product { ProductId = 5, ProductName = "Egg Carton", ProductDescription = "Carton of 12 eggs", ProductPrice = 120, DiscountId = 3, StoreId = 2, Stock = 30 },
            new Product { ProductId = 6, ProductName = "Painted Egg", ProductDescription = "Decorative painted egg", ProductPrice = 30, DiscountId = 5, StoreId = 3, Stock = 25 },
            new Product { ProductId = 7, ProductName = "Quail Egg", ProductDescription = "Small and delicate", ProductPrice = 25, DiscountId = 3, StoreId = 4, Stock = 200 },
            new Product { ProductId = 8, ProductName = "Duck Egg", ProductDescription = "Rich and creamy", ProductPrice = 18, DiscountId = 2, StoreId = 4, Stock = 60 },
            new Product { ProductId = 9, ProductName = "Ostrich Egg", ProductDescription = "Large and exotic", ProductPrice = 150, DiscountId = 4, StoreId = 5, Stock = 5 },
            new Product { ProductId = 10, ProductName = "Caviar Egg", ProductDescription = "Luxurious and rare", ProductPrice = 300, DiscountId = 1, StoreId = 5, Stock = 8 },
            new Product { ProductId = 11, ProductName = "Century Egg", ProductDescription = "Preserved delicacy", ProductPrice = 45, DiscountId = 5, StoreId = 3, Stock = 40 },
            new Product { ProductId = 12, ProductName = "Balut", ProductDescription = "Exotic delicacy", ProductPrice = 35, DiscountId = 3, StoreId = 2, Stock = 70 },
            new Product { ProductId = 13, ProductName = "Egg Nog", ProductDescription = "Festive beverage", ProductPrice = 60, DiscountId = 4, StoreId = 1, Stock = 90 },
            new Product { ProductId = 14, ProductName = "Egg White Protein", ProductDescription = "Health supplement", ProductPrice = 80, DiscountId = 2, StoreId = 5, Stock = 120 },
            new Product { ProductId = 15, ProductName = "Deviled Egg", ProductDescription = "Spicy egg treat", ProductPrice = 25, DiscountId = 4, StoreId = 1, Stock = 55 },
            new Product { ProductId = 16, ProductName = "Egg Salad", ProductDescription = "Classic egg salad", ProductPrice = 50, DiscountId = 3, StoreId = 2, Stock = 85 },
            new Product { ProductId = 17, ProductName = "Scotch Egg", ProductDescription = "Egg wrapped in sausage", ProductPrice = 40, DiscountId = 5, StoreId = 3, Stock = 35 },
            new Product { ProductId = 18, ProductName = "Egg Tart", ProductDescription = "Sweet egg pastry", ProductPrice = 30, DiscountId = 2, StoreId = 4, Stock = 100 },
            new Product { ProductId = 19, ProductName = "Salted Egg", ProductDescription = "Preserved salty egg", ProductPrice = 20, DiscountId = 1, StoreId = 5, Stock = 45 },
            new Product { ProductId = 20, ProductName = "Egg Drop Soup", ProductDescription = "Pre chiken soup", ProductPrice = 35, DiscountId = 3, StoreId = 4, Stock = 110 },
            new Product { ProductId = 21, ProductName = "Eggnog Latte", ProductDescription = "Seasonal eggnog flavored latte", ProductPrice = 45, DiscountId = 4, StoreId = 1, Stock = 95 },
            new Product { ProductId = 22, ProductName = "Egg Rolls", ProductDescription = "Crispy egg rolls with filling", ProductPrice = 30, DiscountId = 2, StoreId = 2, Stock = 130 },
            new Product { ProductId = 23, ProductName = "Egg Mousse", ProductDescription = "Light and fluffy egg mousse", ProductPrice = 55, DiscountId = 1, StoreId = 3, Stock = 40 },
            new Product { ProductId = 24, ProductName = "Egg Pudding", ProductDescription = "Creamy egg pudding", ProductPrice = 40, DiscountId = 3, StoreId = 4, Stock = 75 },
            new Product { ProductId = 25, ProductName = "Egg Sandwich", ProductDescription = "Egg sandwich on whole grain bread", ProductPrice = 35, DiscountId = 5, StoreId = 5, Stock = 65 },
            new Product { ProductId = 26, ProductName = "Egg Tacos", ProductDescription = "Tacos filled with scrambled eggs", ProductPrice = 60, DiscountId = 2, StoreId = 1, Stock = 50 },
            new Product { ProductId = 27, ProductName = "Egg Benedict", ProductDescription = "Poached eggs on English muffin", ProductPrice = 70, DiscountId = 4, StoreId = 2, Stock = 20 },
            new Product { ProductId = 28, ProductName = "Egg Custard", ProductDescription = "Sweet and smooth egg custard", ProductPrice = 50, DiscountId = 3, StoreId = 3, Stock = 55 },
            new Product { ProductId = 29, ProductName = "Egg Muffin", ProductDescription = "Egg and cheese muffin", ProductPrice = 45, DiscountId = 1, StoreId = 4, Stock = 90 },
            new Product { ProductId = 30, ProductName = "Egg Soup", ProductDescription = "Traditional egg drop soup", ProductPrice = 25, DiscountId = 5, StoreId = 5, Stock = 70 }
        );

        // Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName= "Skye", LastName="Jack", Username = "Skye1357", PasswordHash = "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", userRole = "Admin", StoreId = 1 },
            new User { Id = 2, FirstName = "Matthew", LastName = "Jack", Username = "Mtjack1", PasswordHash = "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", userRole = "Manager", StoreId = 2 },
            new User { Id = 3, FirstName = "John", LastName = "Doe", Username = "JD123", PasswordHash = "a60aaf3786de4d0b745b27a8aad0f0b602fbeedbdf7e7881c7f865813808d70a", userRole = "Employee", StoreId = 3 }
        );

        // Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, CustomerName = "Skye Johnson", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 2, CustomerName = "Matthew Smith", LoyaltyCard = true, StoreId = 1 },
            new Customer { CustomerId = 3, CustomerName = "Olivia Brown", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 4, CustomerName = "Liam Johnson", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 5, CustomerName = "Ava Williams", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 6, CustomerName = "Noah Miller", LoyaltyCard = false, StoreId = 3 },
            new Customer { CustomerId = 7, CustomerName = "Emma Davis", LoyaltyCard = false, StoreId = 3 },
            new Customer { CustomerId = 8, CustomerName = "Sophia Wilson", LoyaltyCard = true, StoreId = 4 },
            new Customer { CustomerId = 9, CustomerName = "James Anderson", LoyaltyCard = true, StoreId = 4 },
            new Customer { CustomerId = 10, CustomerName = "Isabella Thomas", LoyaltyCard = false, StoreId = 4 },
            new Customer { CustomerId = 11, CustomerName = "Mason Moore", LoyaltyCard = true, StoreId = 5 },
            new Customer { CustomerId = 12, CustomerName = "Ethan Taylor", LoyaltyCard = false, StoreId = 5 },
            new Customer { CustomerId = 13, CustomerName = "Mia Jackson", LoyaltyCard = true, StoreId = 5 },
            new Customer { CustomerId = 14, CustomerName = "Charlotte Harris", LoyaltyCard = true, StoreId = 1 },
            new Customer { CustomerId = 15, CustomerName = "Henry Clark", LoyaltyCard = false, StoreId = 2 },
            new Customer { CustomerId = 16, CustomerName = "Alexander Lewis", LoyaltyCard = true, StoreId = 3 },
            new Customer { CustomerId = 17, CustomerName = "Amelia King", LoyaltyCard = false, StoreId = 4 },
            new Customer { CustomerId = 18, CustomerName = "Daniel Scott", LoyaltyCard = true, StoreId = 5 },
            new Customer { CustomerId = 19, CustomerName = "Lucas Young", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 20, CustomerName = "Zoe Turner", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 21, CustomerName = "Ella Roberts", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 22, CustomerName = "William Carter", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 23, CustomerName = "Avery Martin", LoyaltyCard = false, StoreId = 3 },
            new Customer { CustomerId = 24, CustomerName = "Logan Walker", LoyaltyCard = true, StoreId = 4 },
            new Customer { CustomerId = 25, CustomerName = "Grace Hill", LoyaltyCard = true, StoreId = 5 },
            new Customer { CustomerId = 26, CustomerName = "Lily Green", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 27, CustomerName = "Hannah Adams", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 28, CustomerName = "Jack Nelson", LoyaltyCard = false, StoreId = 3 },
            new Customer { CustomerId = 29, CustomerName = "Victoria Baker", LoyaltyCard = true, StoreId = 4 },
            new Customer { CustomerId = 30, CustomerName = "Leo Perez", LoyaltyCard = true, StoreId = 5 },
            new Customer { CustomerId = 31, CustomerName = "Isabella Rivera", LoyaltyCard = false, StoreId = 1 },
            new Customer { CustomerId = 32, CustomerName = "David Brooks", LoyaltyCard = true, StoreId = 2 },
            new Customer { CustomerId = 33, CustomerName = "Mason Long", LoyaltyCard = false, StoreId = 3 },
            new Customer { CustomerId = 34, CustomerName = "Samantha Hughes", LoyaltyCard = true, StoreId = 4 },
            new Customer { CustomerId = 35, CustomerName = "Gabriel Murphy", LoyaltyCard = false, StoreId = 5 },
            new Customer { CustomerId = 36, CustomerName = "Abigail Simmons", LoyaltyCard = true, StoreId = 1 },
            new Customer { CustomerId = 37, CustomerName = "Harper Foster", LoyaltyCard = false, StoreId = 2 },
            new Customer { CustomerId = 38, CustomerName = "Oliver Gonzales", LoyaltyCard = true, StoreId = 3 },
            new Customer { CustomerId = 39, CustomerName = "Zoey Bryant", LoyaltyCard = false, StoreId = 4 },
            new Customer { CustomerId = 40, CustomerName = "Scarlett Barnes", LoyaltyCard = true, StoreId = 5 }
        );

        // Purchases
        modelBuilder.Entity<Purchase>().HasData(
            new Purchase { PurchaseId = 1, CustomerId = 1, ProductId = 1, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 15) },
            new Purchase { PurchaseId = 2, CustomerId = 2, ProductId = 2, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 10) },
            new Purchase { PurchaseId = 3, CustomerId = 3, ProductId = 3, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 20) },
            new Purchase { PurchaseId = 4, CustomerId = 4, ProductId = 4, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 5) },
            new Purchase { PurchaseId = 5, CustomerId = 5, ProductId = 5, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 12) },
            new Purchase { PurchaseId = 6, CustomerId = 6, ProductId = 6, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 18) },
            new Purchase { PurchaseId = 7, CustomerId = 7, ProductId = 11, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 23) },
            new Purchase { PurchaseId = 8, CustomerId = 8, ProductId = 7, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 7) },
            new Purchase { PurchaseId = 9, CustomerId = 9, ProductId = 8, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 13) },
            new Purchase { PurchaseId = 10, CustomerId = 10, ProductId = 9, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 3) },
            new Purchase { PurchaseId = 11, CustomerId = 11, ProductId = 10, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 16) },
            new Purchase { PurchaseId = 12, CustomerId = 12, ProductId = 14, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 8) },
            new Purchase { PurchaseId = 13, CustomerId = 13, ProductId = 12, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 20) },
            new Purchase { PurchaseId = 14, CustomerId = 1, ProductId = 13, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 14) },
            new Purchase { PurchaseId = 15, CustomerId = 2, ProductId = 4, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 8) },
            new Purchase { PurchaseId = 16, CustomerId = 3, ProductId = 5, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 28) },
            new Purchase { PurchaseId = 17, CustomerId = 4, ProductId = 6, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 6) },
            new Purchase { PurchaseId = 18, CustomerId = 5, ProductId = 1, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 15) },
            new Purchase { PurchaseId = 19, CustomerId = 6, ProductId = 7, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 25) },
            new Purchase { PurchaseId = 20, CustomerId = 7, ProductId = 8, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 11) },
            new Purchase { PurchaseId = 21, CustomerId = 8, ProductId = 9, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 22) },
            new Purchase { PurchaseId = 22, CustomerId = 9, ProductId = 10, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 12) },
            new Purchase { PurchaseId = 23, CustomerId = 10, ProductId = 11, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 7) },
            new Purchase { PurchaseId = 24, CustomerId = 11, ProductId = 12, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 14) },
            new Purchase { PurchaseId = 25, CustomerId = 12, ProductId = 13, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 29) },
            new Purchase { PurchaseId = 26, CustomerId = 13, ProductId = 14, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 18) },
            new Purchase { PurchaseId = 27, CustomerId = 14, ProductId = 15, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 5) },
            new Purchase { PurchaseId = 28, CustomerId = 15, ProductId = 16, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 13) },
            new Purchase { PurchaseId = 29, CustomerId = 16, ProductId = 17, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 27) },
            new Purchase { PurchaseId = 30, CustomerId = 17, ProductId = 18, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 9) },
            new Purchase { PurchaseId = 31, CustomerId = 18, ProductId = 19, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 2) },
            new Purchase { PurchaseId = 32, CustomerId = 19, ProductId = 20, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 18) },
            new Purchase { PurchaseId = 33, CustomerId = 20, ProductId = 15, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 5) },
            new Purchase { PurchaseId = 34, CustomerId = 21, ProductId = 1, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 20) },
            new Purchase { PurchaseId = 35, CustomerId = 22, ProductId = 2, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 29) },
            new Purchase { PurchaseId = 36, CustomerId = 23, ProductId = 3, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 2) },
            new Purchase { PurchaseId = 37, CustomerId = 24, ProductId = 4, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 4) },
            new Purchase { PurchaseId = 38, CustomerId = 25, ProductId = 5, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 21) },
            new Purchase { PurchaseId = 39, CustomerId = 26, ProductId = 6, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 17) },
            new Purchase { PurchaseId = 40, CustomerId = 27, ProductId = 7, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 6) },
            new Purchase { PurchaseId = 41, CustomerId = 28, ProductId = 8, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 14) },
            new Purchase { PurchaseId = 42, CustomerId = 29, ProductId = 9, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 21) },
            new Purchase { PurchaseId = 43, CustomerId = 30, ProductId = 10, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 28) },
            new Purchase { PurchaseId = 44, CustomerId = 31, ProductId = 11, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 8) },
            new Purchase { PurchaseId = 45, CustomerId = 32, ProductId = 12, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 15) },
            new Purchase { PurchaseId = 46, CustomerId = 33, ProductId = 13, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 11) },
            new Purchase { PurchaseId = 47, CustomerId = 34, ProductId = 14, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 5) },
            new Purchase { PurchaseId = 48, CustomerId = 35, ProductId = 15, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 20) },
            new Purchase { PurchaseId = 49, CustomerId = 36, ProductId = 16, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 9) },
            new Purchase { PurchaseId = 50, CustomerId = 37, ProductId = 17, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 24) },
            new Purchase { PurchaseId = 51, CustomerId = 38, ProductId = 18, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 28) },
            new Purchase { PurchaseId = 52, CustomerId = 39, ProductId = 19, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 3) },
            new Purchase { PurchaseId = 53, CustomerId = 40, ProductId = 20, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 19) },
            new Purchase { PurchaseId = 54, CustomerId = 21, ProductId = 21, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 22) },
            new Purchase { PurchaseId = 55, CustomerId = 22, ProductId = 22, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 30) },
            new Purchase { PurchaseId = 56, CustomerId = 23, ProductId = 23, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 13) },
            new Purchase { PurchaseId = 57, CustomerId = 24, ProductId = 24, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 16) },
            new Purchase { PurchaseId = 58, CustomerId = 25, ProductId = 25, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 29) },
            new Purchase { PurchaseId = 59, CustomerId = 26, ProductId = 26, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 12) },
            new Purchase { PurchaseId = 60, CustomerId = 27, ProductId = 27, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 4) },
            new Purchase { PurchaseId = 61, CustomerId = 28, ProductId = 28, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 19) },
            new Purchase { PurchaseId = 62, CustomerId = 29, ProductId = 29, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 28) },
            new Purchase { PurchaseId = 63, CustomerId = 30, ProductId = 30, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 15) },
            new Purchase { PurchaseId = 64, CustomerId = 31, ProductId = 21, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 27) },
            new Purchase { PurchaseId = 65, CustomerId = 32, ProductId = 22, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 3) },
            new Purchase { PurchaseId = 66, CustomerId = 33, ProductId = 23, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 11) },
            new Purchase { PurchaseId = 67, CustomerId = 34, ProductId = 24, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 24) },
            new Purchase { PurchaseId = 68, CustomerId = 35, ProductId = 25, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 20) },
            new Purchase { PurchaseId = 69, CustomerId = 36, ProductId = 26, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 9, 26) },
            new Purchase { PurchaseId = 70, CustomerId = 37, ProductId = 27, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 10, 7) },
            new Purchase { PurchaseId = 71, CustomerId = 38, ProductId = 28, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 11, 22) },
            new Purchase { PurchaseId = 72, CustomerId = 39, ProductId = 29, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 12, 31) },
            new Purchase { PurchaseId = 73, CustomerId = 40, ProductId = 30, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 1, 30) },
            new Purchase { PurchaseId = 74, CustomerId = 21, ProductId = 22, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 2, 9) },
            new Purchase { PurchaseId = 75, CustomerId = 22, ProductId = 23, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 3, 22) },
            new Purchase { PurchaseId = 76, CustomerId = 23, ProductId = 24, StoreId = 4, PurchaseTime = new DateTime(DateTime.Now.Year, 4, 10) },
            new Purchase { PurchaseId = 77, CustomerId = 24, ProductId = 25, StoreId = 5, PurchaseTime = new DateTime(DateTime.Now.Year, 5, 30) },
            new Purchase { PurchaseId = 78, CustomerId = 25, ProductId = 26, StoreId = 1, PurchaseTime = new DateTime(DateTime.Now.Year, 6, 5) },
            new Purchase { PurchaseId = 79, CustomerId = 26, ProductId = 27, StoreId = 2, PurchaseTime = new DateTime(DateTime.Now.Year, 7, 27) },
            new Purchase { PurchaseId = 80, CustomerId = 27, ProductId = 28, StoreId = 3, PurchaseTime = new DateTime(DateTime.Now.Year, 8, 15) }
        );
    }
}
