namespace DE_Store_Backend.Models;

public class PurchaseItem
{
    public int BasketId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int PurchaseId { get; set; } 
    public Purchase Purchase { get; set; }
}
