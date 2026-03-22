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
    options.IdleTimeout = TimeSpan.FromMinutes(30); // session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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

// ✅ Enable Session (IMPORTANT - before Authorization)
app.UseSession();

app.UseAuthorization();

// ================= ROUTING =================

// ✅ DEFAULT ROUTE (Login page first)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// ✅ OPTIONAL: FIX FOR /Shop/Details/{id}
app.MapControllerRoute(
    name: "shopDetails",
    pattern: "Shop/Details/{id}",
    defaults: new { controller = "Shop", action = "Details" }
);

app.Run();