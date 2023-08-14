var builder = WebApplication.CreateBuilder(args);

/* Application services are registered and configured here. */
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // Adds middleware for using HSTS, which adds the Strict-Transport-Security header to HTTP responses.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

// Serves "index.html" when no other route matches.
app.MapFallbackToFile("index.html");

app.Run();
