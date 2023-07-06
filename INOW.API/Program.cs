using INOW.API.Core;
using INOW.API.Entities;
using INOW.API.Models;
using INOW.API.Persistence;
using INOW.API.Services;
using INOW.API.Utils;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var portVar = Environment.GetEnvironmentVariable("PORT");
    Console.WriteLine(portVar ?? "NULL PORT");
    if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
    {
        options.ListenAnyIP(port);
    }
});


// Add services to the container.

builder.Services.AddNHibernate(builder.Configuration.GetConnectionString("postgresql"));
builder.Services.AddControllers();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(s => MongoClientResolver.Inialize(builder.Configuration));
//builder.Services.AddSingleton(s =>
//{
//    var rec = Receiver.Initialize(builder.Configuration.GetValue<string>("rabbitmq"));
//    rec.Receive();
//    return rec;
//});
builder.Services.AddSwaggerGen();


var app = builder.Build();

var rec = Receiver.Initialize(builder.Configuration.GetValue<string>("rabbitmq"));
rec.Receive();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    //app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

app.Run();