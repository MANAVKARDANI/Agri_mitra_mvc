using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Shops()
    {
        return View();
    }

    public IActionResult AddShop()
    {
        return View();
    }

    public IActionResult Fertilizers()
    {
        return View();
    }

    public IActionResult AddFertilizer()
    {
        return View();
    }
}