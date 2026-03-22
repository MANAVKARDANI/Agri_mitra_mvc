using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    // LOGIN
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            string adminEmail = "admin@gmail.com";

            if (model.Role == "Admin" && model.Email == adminEmail)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (model.Role == "User")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (model.Role == "Supplier")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid Admin Email or Role!";
            }
        }
        return View(model);
    }

    // REGISTER
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Save logic here (DB later)
            return RedirectToAction("Login");
        }
        return View(model);
    }

    // FORGOT PASSWORD
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ForgotPassword(ForgotPasswordViewModel model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.Message = "Reset link sent to your email!";
        }
        return View(model);
    }
}