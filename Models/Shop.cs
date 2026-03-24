public class Shop
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Address { get; set; }

    // 🔥 NEW (for filtering)
    public string State { get; set; }
    public string District { get; set; }
    public string City { get; set; }

    public bool Verified { get; set; }
}