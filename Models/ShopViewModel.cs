public class ShopViewModel
{
    public List<Shop> Shops { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}

public class Shop
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Address { get; set; }
    public bool Verified { get; set; }
}