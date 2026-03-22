using Microsoft.AspNetCore.Mvc;

public class ShopController : Controller
{
    public IActionResult Index(int page = 1)
    {
        var shops = new List<Shop>
        {
            new Shop { Id="farma-fer", Name="Farma Fer", Image="/images/Farma Fer.png", Address="124 Agri Lane", Verified=true },
            new Shop { Id="valley-fertilizers", Name="Valley Fertilizers", Image="/images/Valley Fertilizers.png", Address="88 Farm Road", Verified=true },
            new Shop { Id="eco-crop", Name="EcoCrop Solutions", Image="/images/EcoCrop Solutions.png", Address="45 Sustainable Way", Verified=true },
            new Shop { Id="growers-choice", Name="Growers Choice", Image="/images/Growers Choice.png", Address="22 Plantation Drive", Verified=false },
            new Shop { Id="natures-best", Name="Nature's Best Agri", Image="/images/Nature's Best Agri.png", Address="78 Organic Blvd", Verified=false },
            new Shop { Id="modern-farmer", Name="Modern Farmer Supply", Image="/images/Modern Farmer Supply.png", Address="101 Innovation Road", Verified=true },
            new Shop { Id="plant-power", Name="Plant Power Store", Image="/images/Plant Power Store.png", Address="33 Green Avenue", Verified=false },
            new Shop { Id="root-shoot", Name="Root & Shoot Suppliers", Image="/images/Root & Shoot Suppliers.png", Address="56 Growth Street", Verified=false }
        };

        int pageSize = 8;
        var pagedData = shops.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var model = new ShopViewModel
        {
            Shops = pagedData,
            CurrentPage = page,
            TotalPages = (int)Math.Ceiling(shops.Count / (double)pageSize)
        };

        return View(model);
    }
}