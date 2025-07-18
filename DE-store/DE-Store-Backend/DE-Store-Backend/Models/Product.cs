using System.Text.Json.Serialization;

namespace DE_Store_Backend.Models;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public int ProductPrice { get; set; }
    public int StoreId { get; set; }
    [JsonIgnore]
    public Store Store { get; set; }
    [JsonIgnore]
    public int DiscountId { get; set; }
    public Discount Discount { get; set; }
    public int Stock {  get; set; }
}
