using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gameDeal.Models;
using System.Text.Json;


namespace gameDeal.Controllers;

public class SearchController : Controller {

    public IActionResult Index() {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Results(string game) { 
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
