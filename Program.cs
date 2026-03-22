using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ================= SERVICES =================

// Add MVC
builder.Services.AddControllersWithViews();

// ✅ Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// (Optional but recommended)
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ================= MIDDLEWARE =================

// Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ Session MUST come before Authorization
app.UseSession();

app.UseAuthorization();

// ================= ROUTING =================

// ✅ Default route (Login first)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}"
);

// ✅ Shop Details Route (SEO friendly)
app.MapControllerRoute(
    name: "shopDetails",
    pattern: "shop/{id}",
    defaults: new { controller = "Shop", action = "Details" }
);

// ✅ Product Details Route (Fix 404)
app.MapControllerRoute(
    name: "productDetails",
    pattern: "product/details",
    defaults: new { controller = "Shop", action = "ProductDetails" }
);

// ✅ Billing Route
app.MapControllerRoute(
    name: "billing",
    pattern: "billing",
    defaults: new { controller = "Shop", action = "Billing" }
);

app.Run();