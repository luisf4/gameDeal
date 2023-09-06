using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gameDeal.Models;

namespace gameDeal.Controllers;

public class ApiController : Controller {

    private string apikey = "GEI0DCLRW3HGMQJQ";


    public string Index()
    {
        return "Hello from Api";
    }

    public async Task<IActionResult> GetApiData() {
        var client = new HttpClient();
        var response = await client.GetAsync("https://www.cheapshark.com/api/1.0/deals?storeID=1&upperPrice=15");
        var content = await response.Content.ReadAsStringAsync();
        return Content(content);

    }
}
