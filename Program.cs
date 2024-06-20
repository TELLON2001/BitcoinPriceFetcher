using BitcoinPriceFetcher.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BitcoinPriceContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BitcoinPriceContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
