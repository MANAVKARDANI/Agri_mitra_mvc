using System.Collections.Generic;

namespace Agri_mitra.Models
{
    public class ShopViewModel
    {
        public List<Shop> Shops { get; set; }

        // ✅ REQUIRED FOR FILTER
        public string State { get; set; }
        public string District { get; set; }
        public string City { get; set; }

        // ✅ REQUIRED FOR DROPDOWN
        public Dictionary<string, Dictionary<string, List<string>>> LocationData { get; set; }

        // ✅ PAGINATION
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}