// Initializes a new instance of the WebApplicationBuilder class with preconfigured defaults.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Builds the WebApplication.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Adds middleware for using HSTS, which adds the Strict-Transport-Security header (default 30 days)
    app.UseHsts();
}

// Enables static file serving for the current request path.
app.UseStaticFiles();

// Configures the application routing and their mapping to controller actions.
app.UseRouting();
app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");

// Adds a specialized endpoint for the default file name (index.html) to serve the client app, which also handles the 404 route.
app.MapFallbackToFile("index.html");

// Runs an application and block the calling thread until host shutdown.
app.Run();
