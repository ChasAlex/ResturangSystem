using Microsoft.EntityFrameworkCore;
using ResturangSystem.Data;
using ResturangSystem.Data.Repos;
using ResturangSystem.Data.Repos.IRepos;
using ResturangSystem.Service;
using ResturangSystem.Service.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ResturangContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IBokningRepo, BokningRepo>();
builder.Services.AddScoped<IBordRepo, BordRepo>();
builder.Services.AddScoped<IKundRepo, KundRepo>();
builder.Services.AddScoped<IMenyRepo, MenyRepo>();
builder.Services.AddScoped<IResturangRepo, ResturangRepo>();
builder.Services.AddScoped<IBokningService, BokningService>();
builder.Services.AddScoped<IBordService, BordService>();
builder.Services.AddScoped<IKundService, KundService>();
builder.Services.AddScoped<IMenyService, MenyService>();
builder.Services.AddScoped<IResturangService, ResturangService>();

var app = builder.Build();

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
