using DE_Store_Backend.Data;
using Microsoft.AspNetCore.Mvc;
using DE_Store_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace DE_Store_Backend.Controllers;

public class GetStoreStockDto
{
    public int StoreId { get; set; }
}

public class UpdateProductDto 
{
    public int ProductId { get; set; }
    public int ProductPrice { get; set; }
    public int ProductStock { get; set; }
    public string DiscountType { get; set; }
}


[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    [HttpPost("updateProduct")]
    public IActionResult UpdateProduct([FromBody] UpdateProductDto updatedProduct)
    {
        using ApplicationDbContext _context = new ApplicationDbContext();
        var targetProduct = _context.Products.FirstOrDefault(product => product.ProductId == updatedProduct.ProductId);

        if (targetProduct == null)
        {
            return NotFound($"No matching product found for productId: {updatedProduct.ProductId}");
        }

        var updatedDiscount = _context.Discounts.FirstOrDefault(discount => discount.DiscountType == updatedProduct.DiscountType);

        if (updatedDiscount == null)
        {
            return NotFound("Incorrect discount");
        }

        targetProduct.Stock = updatedProduct.ProductStock;
        targetProduct.ProductPrice = updatedProduct.ProductPrice;
        targetProduct.DiscountId = updatedDiscount.Id;
        _context.SaveChanges();

        return Ok(targetProduct);
    }

    [HttpGet("GetStoreStock")]
    public List<Product> GetStoreStock([FromQuery] GetStoreStockDto getStoreStockDto)
    {
        using ApplicationDbContext _context = new ApplicationDbContext();
        var targetStore = _context.Stores.Include(s => s.Products).ThenInclude(p => p.Discount).FirstOrDefault(s => s.StoreId == getStoreStockDto.StoreId);

        if (targetStore != null)
        {
            var stock = targetStore.Products;
            return stock;
        }

        return new();
    }
}
