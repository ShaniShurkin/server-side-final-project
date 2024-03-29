using BL;
using Microsoft.Extensions.Configuration;
using UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

var dbsettings = config.GetSection("PlatePlanDatabase").Get<Dictionary<string, string>>();
builder.Services.AddControllers();

builder.Services.AddServices(dbsettings);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();


builder.Services.AddCors(options =>
    {
        var frontendURL = configuration.GetValue<string>("frontend_url");
        var all = configuration.GetValue<string>("Microsoft.AspNetCore");
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader(); 
            });
    }
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
