using RepoDL;
using ESLogic;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DL_Interface>(context => new Customer_Repo(builder.Configuration.GetConnectionString("ESDB")));
builder.Services.AddScoped<BL_Interface, Customer_BL>();

builder.Services.AddScoped<DL_Interface>(context => new Staff_Repo(builder.Configuration.GetConnectionString("ESDB")));
builder.Services.AddScoped<BL_Interface, Staff_BL>();

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
