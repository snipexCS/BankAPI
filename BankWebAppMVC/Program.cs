using BankWebAppMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add IHttpClientFactory if needed (optional for RestSharp, but good for future)
builder.Services.AddHttpClient();

// Provide the BankApiService with the base URL explicitly
string apiBaseUrl = "https://localhost:7276"; // your API base URL
builder.Services.AddScoped(sp => new BankApiService(apiBaseUrl));

// Add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.MapDefaultControllerRoute();

app.Run();
