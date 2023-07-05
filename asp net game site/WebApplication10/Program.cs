using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Protocol;
using System;
using WebApplication10.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Game>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Game") ?? throw new InvalidOperationException("Connection string 'Game' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Game>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.MapGet("/getHPandSpeed",(Game db)=> Results.Json(db.Presets.ToList()));

app.Run();