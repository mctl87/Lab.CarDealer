using CarDealer.Client.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("CarDealerAPIClient", client => {
    //client.BaseAddress = new Uri("http://localhost:8000");
    client.BaseAddress = new Uri(builder.Configuration["CarDealerAPIUrl"]);
});
builder.Services.AddControllersWithViews().AddJsonOptions(o => {
    o.JsonSerializerOptions.PropertyNamingPolicy = new UpperCaseNamingPolicy();
    o.JsonSerializerOptions.WriteIndented = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
