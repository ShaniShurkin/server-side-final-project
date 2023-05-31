using BL;
using UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PlatePlanDatabase").GetSection("ConnectionString").Value;
var DatabaseName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PlatePlanDatabase").GetSection("DatabaseName").Value;
var ClientsCollectionName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PlatePlanDatabase").GetSection("ClientsCollectionName").Value;
var FoodsCollectionName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("PlatePlanDatabase").GetSection("FoodCollectionName").Value;
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("PlatePlanDatabase"));
builder.Services.AddControllers();

builder.Services.AddServices(ConnectionString, DatabaseName, ClientsCollectionName, FoodsCollectionName);

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
