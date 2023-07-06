using INOW.API.Core;
using INOW.API.Persistence;
using INOW.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    var portVar = Environment.GetEnvironmentVariable("PORT");
    if (portVar is { Length: > 0 } && int.TryParse(portVar, out int port))
    {
        options.ListenAnyIP(port, listenOptions =>
        {
            listenOptions.UseHttps();
        });
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
builder.Services.AddSwaggerGen();

var app = builder.Build();

var rec = Receiver.Initialize(builder.Configuration.GetValue<string>("rabbitmq"));
rec.Receive();

//app.UseCors(c => {
//    c.AllowAnyOrigin();
//    c.AllowAnyMethod();
//    c.AllowAnyHeader();
//}); 

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();
app.MapControllers();

app.Run();