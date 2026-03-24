using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Agri_mitra.Models;

namespace Agri_mitra.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index(string state, string district, string city, int page = 1)
        {
            var shops = GetShops();

            // 🔥 FILTER
            if (!string.IsNullOrEmpty(state))
                shops = shops.Where(s => s.State == state).ToList();

            if (!string.IsNullOrEmpty(district))
                shops = shops.Where(s => s.District == district).ToList();

            if (!string.IsNullOrEmpty(city))
                shops = shops.Where(s => s.City == city).ToList();

            int pageSize = 8;

            var pagedData = shops
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var model = new ShopViewModel
            {
                Shops = pagedData,

                // ✅ IMPORTANT FIX
                State = state,
                District = district,
                City = city,

                LocationData = GetLocations(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(shops.Count / (double)pageSize)
            };

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var shop = GetShops().FirstOrDefault(s => s.Id == id);

            if (shop == null)
                return NotFound();

            return View(shop);
        }

        private Dictionary<string, Dictionary<string, List<string>>> GetLocations()
        {
            return new Dictionary<string, Dictionary<string, List<string>>>
            {
                ["Gujarat"] = new Dictionary<string, List<string>>
                {
                    ["Rajkot"] = new List<string> { "Rajkot City", "Gondal" },
                    ["Ahmedabad"] = new List<string> { "Ahmedabad City", "Sanand" },
                    ["Surat"] = new List<string> { "Surat City", "Bardoli" }
                },
                ["Maharashtra"] = new Dictionary<string, List<string>>
                {
                    ["Pune"] = new List<string> { "Pune City", "Hinjewadi" },
                    ["Mumbai"] = new List<string> { "Andheri", "Borivali" }
                },
                ["Rajasthan"] = new Dictionary<string, List<string>>
                {
                    ["Jaipur"] = new List<string> { "Jaipur City" },
                    ["Udaipur"] = new List<string> { "Udaipur City" }
                }
            };
        }

        private List<Shop> GetShops()
        {
            return new List<Shop>
            {
                new Shop { Id="farma-fer", Name="Farma Fer", Image="/images/Farma Fer.png", Address="Rajkot, Gujarat", State="Gujarat", District="Rajkot", City="Rajkot City", Verified=true },
                new Shop { Id="valley", Name="Valley Fertilizers", Image="/images/Valley Fertilizers.png", Address="Ahmedabad, Gujarat", State="Gujarat", District="Ahmedabad", City="Ahmedabad City", Verified=true },
                new Shop { Id="eco", Name="EcoCrop Solutions", Image="/images/EcoCrop Solutions.png", Address="Surat, Gujarat", State="Gujarat", District="Surat", City="Surat City", Verified=true },
                new Shop { Id="growers", Name="Growers Choice", Image="/images/Growers Choice.png", Address="Pune, Maharashtra", State="Maharashtra", District="Pune", City="Pune City", Verified=false },
                new Shop { Id="nature", Name="Nature's Best Agri", Image="/images/Nature's Best Agri.png", Address="Mumbai, Maharashtra", State="Maharashtra", District="Mumbai", City="Andheri", Verified=false },
                new Shop { Id="modern", Name="Modern Farmer Supply", Image="/images/Modern Farmer Supply.png", Address="Jaipur, Rajasthan", State="Rajasthan", District="Jaipur", City="Jaipur City", Verified=true },
                new Shop { Id="plant", Name="Plant Power Store", Image="/images/Plant Power Store.png", Address="Udaipur, Rajasthan", State="Rajasthan", District="Udaipur", City="Udaipur City", Verified=false },
                new Shop { Id="root", Name="Root & Shoot Suppliers", Image="/images/Root & Shoot Suppliers.png", Address="Rajkot, Gujarat", State="Gujarat", District="Rajkot", City="Gondal", Verified=false }
            };
        }
    }
}