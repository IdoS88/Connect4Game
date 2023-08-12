
using IdoShamir_EyalCohen_Connect4.Data;
using IdoShamir_EyalCohen_Connect4.Repositories;
using IdoShamir_EyalCohen_Connect4.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerContext") ?? throw new InvalidOperationException("Connection string 'ServerContext' not found.")));

builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
