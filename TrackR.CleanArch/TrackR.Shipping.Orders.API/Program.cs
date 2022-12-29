
using TrackR.Shipping.Orders.Application;
using TrackR.Shipping.Orders.Infrastructure;
using TrackR.Shipping.Orders.Infrastructure.Configuration;
using TrackR.Shipping.Orders.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hosting, config) =>
{
    var currentDirectory = Directory.GetCurrentDirectory();
    config
        .SetBasePath(currentDirectory)
        .AddJsonFile($"{currentDirectory}/conf/appsettings.json");
});

var applicationSettings = builder.Configuration.GetSection("ApplicationSettings").Get<Settings>();

builder.Services.AddSingleton<ISettings>(applicationSettings);

builder.Services
    .AddKafka(applicationSettings.KafkaSettings)
    .AddInfrastructure()
    .AddApplication()
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
