using BasketApi.Extensions;
using BasketApi.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

builder.Services.AddDatabase().AddServices();

var app = builder.Build();

app.Configuration
    .GetSection("AppSettings")
    .Get<AppSettings>(options => options.BindNonPublicProperties = true);

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

IConfiguration InitConfiguration(string environmentName)
{
    // Config the app to read values from appsettings base on current environment value.
    var configuration = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", false, true)
        .AddJsonFile($"appsettings.{environmentName}.json", true, true)
        .AddEnvironmentVariables().Build();

    // Map AppSettings section in appsettings.json file value to AppSetting model
    configuration.GetSection("AppSettings").Get<AppSettings>(options => options.BindNonPublicProperties = true);
    return configuration;
}