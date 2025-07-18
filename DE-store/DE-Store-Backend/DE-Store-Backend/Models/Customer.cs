using System.Text.Json.Serialization;

namespace DE_Store_Backend.Models;

public class Customer
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public bool LoyaltyCard { get; set; }
    [JsonIgnore]
    public Store Store { get; set; }
    public int StoreId { get; set; }
}
