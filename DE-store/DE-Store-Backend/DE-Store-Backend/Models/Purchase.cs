using System.Text.Json.Serialization;

namespace DE_Store_Backend.Models;

public class Purchase
{
    public int PurchaseId { get; set; }
    public DateTime PurchaseTime { get; set; }
    [JsonIgnore]
    public Store Store { get; set; }    
    public int StoreId { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
}
