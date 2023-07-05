using INOW.API.Core;
using INOW.API.Entities;
using INOW.API.Models;
using INOW.API.Persistence;
using INOW.API.Services;
using INOW.API.Utils;
using MongoDB.Bson;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {

        // For running in Railway
        var portVar = Environment.GetEnvironmentVariable("PORT");
        if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
        {
            webBuilder.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(port);
            });
        }
    });


// Add services to the container.

builder.Services.AddNHibernate(Util.getConnectionStringFromEnvironment());
builder.Services.AddControllers();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(s => MongoClientResolver.Inialize(builder.Configuration));
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();