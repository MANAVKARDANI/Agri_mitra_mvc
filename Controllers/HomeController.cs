using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace YourProjectName.Controllers
{
    public class HomeController : Controller
    {
        // ================= HOME PAGE =================
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Image = "/images/nitrogen.png",
                        Title = "Nitrogen Series",
                        Description = "Rapid vegetative growth."
                    },
                    new Product
                    {
                        Image = "/images/Phosphorus.png",
                        Title = "Phosphorus Boost",
                        Description = "Robust root systems."
                    },
                    new Product
                    {
                        Image = "/images/Potassium.png",
                        Title = "Potassium Shield",
                        Description = "Disease resistance."
                    }
                },

                FeaturedProducts = new List<FeaturedProduct>
                {
                    new FeaturedProduct
                    {
                        Image = "/images/Bio dap.png",
                        Name = "Bio DAP",
                        Description = "Organic Compound"
                    },
                    new FeaturedProduct
                    {
                        Image = "/images/potash.png",
                        Name = "Potash",
                        Description = "Potassium Rich"
                    },
                    new FeaturedProduct
                    {
                        Image = "/images/UREA.png",
                        Name = "Urea",
                        Description = "High Nitrogen"
                    },
                    new FeaturedProduct
                    {
                        Image = "/images/Calcium Nitrate.png",
                        Name = "Calcium Nitrate",
                        Description = "Soluble Grade"
                    }
                }
            };

            return View(model);
        }

        // ================= ABOUT PAGE =================
        public IActionResult About()
        {
            return View();
        }

        // ================= CONTACT (GET) =================
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        // ================= CONTACT (POST) =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string Name, string Email, string Subject, string Message)
        {
            if (!string.IsNullOrEmpty(Name) &&
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(Message))
            {
                // 👉 You can save to DB or send email here

                TempData["Success"] = "Message sent successfully!";
                return RedirectToAction("Contact");
            }

            TempData["Error"] = "Please fill all required fields!";
            return View();
        }
    }
}