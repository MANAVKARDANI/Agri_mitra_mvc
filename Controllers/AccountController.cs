using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

public class AccountController : Controller
{
    // ================= LOGIN =================
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

            // STORE SESSION
            HttpContext.Session.SetString("UserEmail", model.Email);
            HttpContext.Session.SetString("UserRole", model.Role);

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

    // ================= REGISTER =================
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Login");
        }
        return View(model);
    }

    // ================= FORGOT PASSWORD =================
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

    // ================= LOGOUT =================
    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Account");
    }

    // ================= PROFILE =================
    public IActionResult Profile()
    {
        // No DB used
        ViewBag.Email = User.Identity.Name;

        // Optional: name from email
        ViewBag.Name = User.Identity.Name?.Split('@')[0];

        return View();
    }

    // ================= EDIT PROFILE (GET) =================
    [HttpGet]
    public IActionResult EditProfile()
    {
        ViewBag.Name = HttpContext.Session.GetString("UserEmail") ?? "User";
        ViewBag.Email = HttpContext.Session.GetString("UserEmail") ?? "user@gmail.com";

        return View();
    }

    // ================= EDIT PROFILE (POST) =================
    [HttpPost]
    public IActionResult EditProfile(string Name, string Email)
    {
        // Save updated data (for now session only)
        HttpContext.Session.SetString("UserEmail", Email);

        TempData["Success"] = "Profile updated successfully!";

        return RedirectToAction("Profile");
    }
}