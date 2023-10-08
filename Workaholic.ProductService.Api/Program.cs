using Microsoft.EntityFrameworkCore;
using Workaholic.ProductService.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var a = builder.Configuration["SqlConStr"];
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddDbContext<UdemyUnitTestDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration["SqlConStr"]);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<UdemyUnitTestDBContext>();

        DbInitializer.InitializeSqlServer(context);
    }
    catch (Exception ex)
    {
        System.Console.Write("Oluşmadı");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();