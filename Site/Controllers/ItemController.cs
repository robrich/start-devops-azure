using Microsoft.AspNetCore.Mvc;
using Site.Models;

namespace Site.Controllers;

[ApiController]
[Route("api/item")]
public class ItemController
{
    public List<Item> Get()
    {
        return new List<Item>
        {
            new Item { Id = 1, Name = "One" },
            new Item { Id = 2, Name = "Two" }
        };
    }
}
