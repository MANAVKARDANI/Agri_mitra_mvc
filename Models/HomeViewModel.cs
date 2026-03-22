public class HomeViewModel
{
    public List<Product> Products { get; set; }
    public List<FeaturedProduct> FeaturedProducts { get; set; }
}

public class Product
{
    public string Image { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}

public class FeaturedProduct
{
    public string Image { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}