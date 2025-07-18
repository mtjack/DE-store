namespace DE_Store_Backend.Models;

public class Store
{
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public List<User> Users { get; set; } = new List<User>();
    public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    public List<Customer> Customers { get; set; } = new List<Customer>();
}
