using INOW.API.Core;
using INOW.API.Persistence;
using INOW.API.Services;

var builder = WebApplication.CreateBuilder(args);

//retrieve port from environment variables
var port = builder.Configuration["PORT"];

//set listening urls
builder.WebHost.UseUrls($"https://*:{port};http://localhost:5001");


// Add services to the container.

builder.Services.AddNHibernate(builder.Configuration.GetConnectionString("postgresql"));
builder.Services.AddControllers();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(s => MongoClientResolver.Inialize(builder.Configuration));
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

var rec = Receiver.Initialize(builder.Configuration.GetValue<string>("rabbitmq"));
rec.Receive();

app.UseCors("MyPolicy");

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