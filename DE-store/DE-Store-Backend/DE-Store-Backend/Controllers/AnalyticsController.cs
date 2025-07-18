using DE_Store_Backend.Data;
using DE_Store_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DE_Store_Backend.Controllers;

public class StoreSalesAnalyticsDto
{
    public int StoreId { get; set; }
}

public class StoreProductAnalyticsRequestDto
{
    public int StoreId { get; set; }
}

public class StoreSalesByDateRequestDto
{
    public int StoreId { get; set; }
    public int Days { get; set; }
}

public class StorePurchaseByDateResultDto
{
    public string StoreName { get; set; }
    public int TotalPurchases { get; set; }
    public decimal TotalPrice { get; set; }
}


public class StoreSalesAnalyticsResultDto
{
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
}

public class StoreProductAnalyticsResultDto
{
    public string StoreName { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public int TotalPrice { get; set; }
}

public class MonthlySalesDto
{
    public int Year { get; set; }
    public int Month { get; set; }
    public int TotalSales { get; set; }
    public decimal TotalRevenue { get; set; }
}


[Route("api/[controller]")]
[ApiController]
public class AnalyticsController : ControllerBase
{
    [HttpGet("salesAnalytics")]
    public IActionResult SalesAnalytics([FromQuery] StoreSalesAnalyticsDto storeSalesAnalyticsDto)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        var results = context.Stores.Include(s => s.Purchases)
            .ThenInclude(purchase => purchase.Product)
            .Where(s => s.StoreId == storeSalesAnalyticsDto.StoreId)
            .Select(p => new StoreSalesAnalyticsResultDto
            {
                StoreId = p.StoreId,
                StoreName = p.StoreName,
                Quantity = p.Purchases.Count(),
                TotalPrice = p.Purchases.Sum(purchase => purchase.Product.ProductPrice)
            }).ToList();

        // If no results found, return NotFound
        if (results == null || results.Count == 0)
        {
            return NotFound(new { Message = "No sales data found for the given store." });
        }

        return Ok(results);
    }

    [HttpGet("storeProductAnalytics")]
    public IActionResult StoreProductAnalytics([FromQuery] StoreProductAnalyticsRequestDto RequestDto)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        var results = context.Stores
                      .Where(s => s.StoreId == RequestDto.StoreId)
                      .SelectMany(s => s.Purchases, (s, p) => new { s.StoreName, Purchase = p })
                      .GroupBy(sp => new { sp.StoreName, sp.Purchase.Product.ProductName })
                      .Select(g => new StoreProductAnalyticsResultDto
                      {
                          StoreName = g.Key.StoreName,
                          ProductName = g.Key.ProductName,
                          Quantity = g.Count(),
                          TotalPrice = g.Count() * g.First().Purchase.Product.ProductPrice
                      })
                      .ToList();

        // If no results found, return NotFound
        if (results == null || results.Count == 0)
        {
            return NotFound(new { Message = "No product analytics data found for the given store." });
        }

        return Ok(results);
    }

    [HttpGet("storeSalesByDateAnalytics")]
    public IActionResult StorePurchaseByDate([FromQuery] StoreSalesByDateRequestDto RequestDto)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        var dateRange = DateTime.Now.Date.AddDays(-RequestDto.Days);

        var result = context.Stores
                    .Where(s => s.StoreId == RequestDto.StoreId)
                    .SelectMany(s => s.Purchases, (s, p) => new { s.StoreName, Purchase = p })
                    .Where(sp => sp.Purchase.PurchaseTime >= dateRange)
                    .GroupBy(sp => sp.StoreName)
                    .Select(g => new StorePurchaseByDateResultDto
                    {
                        StoreName = g.Key,
                        TotalPurchases = g.Count(),
                        TotalPrice = g.Sum(x => x.Purchase.Product.ProductPrice)
                    })
                    .FirstOrDefault();

        // Check if the result is null and return an appropriate response
        if (result == null)
        {
            return NotFound(new { Message = "No sales data found for the given store and date range." });
        }

        return Ok(result);
    }

    [HttpGet("monthlySalesAnalytics")]
    public IActionResult GetMonthlySalesAnalytics([FromQuery] int storeId)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        // Set the start date to the beginning of the current year
        var startDate = new DateTime(DateTime.Now.Year, 1, 1);
        var endDate = DateTime.Now; // Current date

        // Generate a list of all months in the current year
        var allMonths = Enumerable.Range(0, 12)
            .Select(i => new { Year = startDate.Year, Month = i + 1 }) // Months 1 to 12
            .Where(d => new DateTime(d.Year, d.Month, 1) <= endDate)
            .ToList();

        // Get the actual sales data, grouped by month
        var salesData = context.Purchases
            .Where(p => p.StoreId == storeId && p.PurchaseTime >= startDate)
            .GroupBy(p => new { p.PurchaseTime.Year, p.PurchaseTime.Month })
            .Select(g => new MonthlySalesDto
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                TotalSales = g.Count(),
                TotalRevenue = g.Select(p => p.Product).Sum(product => product.ProductPrice)
            })
            .ToList();

        // Combine the allMonths list with the salesData
        var result = allMonths
            .GroupJoin(
                salesData,
                am => new { am.Year, am.Month },
                sd => new { sd.Year, sd.Month },
                (am, sd) => new MonthlySalesDto
                {
                    Year = am.Year,
                    Month = am.Month,
                    TotalSales = sd.FirstOrDefault()?.TotalSales ?? 0,
                    TotalRevenue = sd.FirstOrDefault()?.TotalRevenue ?? 0m
                }
            )
            .OrderBy(ms => ms.Month)
            .ToList();

        return Ok(result);
    }


}
