using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using gameDeal.Models;

namespace gameDeal.Controllers;

public class HomeController : Controller {
    public string Index()
    {
        return "Hello from Home";
    }
}
