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
}