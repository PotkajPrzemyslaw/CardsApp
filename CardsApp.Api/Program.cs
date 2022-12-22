using CardsApp.Api.Repositories;
using CardsApp.Api.Repositories.Interfaces;
using CardsApp.Api.Services;
using CardsApp.Api.Services.Interfaces;
using CardsApp.Data;
using CardsApp.Data.Initializers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(n =>
{
    n.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext)), options =>
    {
        options.CommandTimeout(600);
        options.EnableRetryOnFailure();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICardsService, CardsService>();

builder.Services.AddTransient<ICardsRepository, CardsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

if (scopeFactory != null)
{
    var scope = scopeFactory.CreateScope();
    var dbContext = scope.ServiceProvider.GetService<AppDbContext>();
    if (dbContext != null)
    {
        await dbContext.Database.MigrateAsync();
        await SeedData(dbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task SeedData(AppDbContext db)
{
    await AppDbInitializer.SeedAsync(db);
}