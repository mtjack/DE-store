using System.Text.Json.Serialization;

namespace DE_Store_Backend.Models;

public class Discount
{
    [JsonIgnore]
    public int Id { get; set; }
    public required string DiscountType { get; set; } 
}
