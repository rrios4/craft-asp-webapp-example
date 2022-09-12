using crafts_webapp.Models;
using crafts_webapp.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    //endpoints.MapGet("/products", (context) =>
    //{
    //    var products = app.Services.GetRequiredService<JsonFileProductService>().GetProducts();
    //    var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
    //    return context.Response.WriteAsync(json);

    //});
});

app.Run();
