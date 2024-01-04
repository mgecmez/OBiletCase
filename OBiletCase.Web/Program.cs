using Microsoft.AspNetCore.HttpOverrides;
using OBiletCase.Core.ExternalApis.Models;
using OBiletCase.Core.ExternalApis;
using OBiletCase.Core.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.Configure<OBiletApiConfig>(builder.Configuration.GetSection("Endpoints:oBiletApi"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMemoryCache();

builder.Services.AddSingleton<OBiletApiService>();
builder.Services.AddSingleton<ClientSessionService>();
builder.Services.AddSingleton<BusLocationService>();
builder.Services.AddSingleton<BusJourneyService>();

builder.Services.AddDetection();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseDetection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseRouting();

app.UseAuthorization();

app.UseCookiePolicy();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
