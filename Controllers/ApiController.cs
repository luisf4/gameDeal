using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gameDeal.Models;
using System.Text.Json;


namespace gameDeal.Controllers;

public class ApiController : Controller {


    public async Task<IActionResult> Index() {
        var client = new HttpClient();
        var res = await client.GetAsync("https://www.cheapshark.com/api/1.0/deals?storeID=1&upperPrice=15");
        
        if (res.IsSuccessStatusCode) {
            var content = await res.Content.ReadAsStringAsync();
            var deals = JsonSerializer.Deserialize<List<Deal>>(content);
            return View(deals);
        }
        else {
            // Handle error response here
            return View(new List<Deal>()); // You can also redirect to an error page
        }
    }


    public async Task<IActionResult> Search(string game) { 
        var client = new HttpClient();
        var res = await client.GetAsync($"https://www.cheapshark.com/api/1.0/games?title={game}");

        if (res.IsSuccessStatusCode) {
            var content = await res.Content.ReadAsStreamAsync();
            var deals = JsonSerializer.Deserialize<List<DealSearch>>(content);
            return View(deals);
        }
        else {
            return View(new List<DealSearch>());
        }
    }

}
