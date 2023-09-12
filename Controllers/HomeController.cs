using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gameDeal.Models;

namespace gameDeal.Controllers;

public class HomeController : Controller {
    public IActionResult Index() {
        return View();
    }


}
