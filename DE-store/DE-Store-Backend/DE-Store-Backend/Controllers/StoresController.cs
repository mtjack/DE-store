using DE_Store_Backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace DE_Store_Backend.Controllers;

public class AllStoresReturnDto
{
    public int StoreId { get; set; }
    public string StoreName { get; set; }
}

[Route("api/[controller]")]
[ApiController]
public class StoresController : ControllerBase
{
    [HttpGet("allStores")]
    public List<AllStoresReturnDto> AllStores()
    {
        using ApplicationDbContext context = new ApplicationDbContext();
        var stores = context.Stores.Select(x => new AllStoresReturnDto { StoreId = x.StoreId, StoreName = x.StoreName }).ToList();
        return stores;
    }
}

