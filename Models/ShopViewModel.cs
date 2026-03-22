using System.Collections.Generic;

public class ShopViewModel
{
    public List<Shop> Shops { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}