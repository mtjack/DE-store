using DE_Store_Backend.Data;
using DE_Store_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Text.Json.Serialization;

namespace DE_Store_Backend.Controllers;
public class GetStoresCustomersDto 
{
    public int storeId { get; set; }
}

public class CustomerWithPurchasesDto
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public bool LoyaltyCard { get; set; }
    public int TotalItemsBought { get; set; }
    public int TotalSpend { get; set; }
}


[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    [HttpGet("customers")]
    public List<Customer> getAllCustomers()
    {
        using ApplicationDbContext context = new ApplicationDbContext();
        var customers = context.Customers.ToList();
        return customers;
    }

    [HttpPost("setLoyaltyCard")]
    public IActionResult SetLoyaltyCard([FromBody] int customerId)
    {
        using ApplicationDbContext context = new ApplicationDbContext();
        var targetCustomer = context.Customers.FirstOrDefault(c => c.CustomerId == customerId);

        if (targetCustomer == null)
        {
            return BadRequest();
        }

        targetCustomer.LoyaltyCard = !targetCustomer.LoyaltyCard;
        context.SaveChanges();

        return Ok();
    }

    [HttpGet("storesCustomers")] 
    public List<CustomerWithPurchasesDto> getStoresCustomers([FromQuery] GetStoresCustomersDto dto)
    {
        using ApplicationDbContext context = new ApplicationDbContext();

        var customers = context.Customers
        .Where(c => c.StoreId == dto.storeId)
        .GroupJoin(
            context.Purchases,
            c => c.CustomerId,
            p => p.CustomerId,
            (customer, purchases) => new CustomerWithPurchasesDto
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                LoyaltyCard = customer.LoyaltyCard,
                TotalItemsBought = purchases.Count(),
                TotalSpend = purchases.Sum(p => p.Product.ProductPrice)
            }
        )
        .ToList();

        return customers;
    }
}
