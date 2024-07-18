using BluesoftBank.Models;
using BluesoftBank.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//inicializo en contexto
builder.Services.AddSqlServer<BlueSoftBankContext>(builder.Configuration.GetConnectionString("cnBlueSoft"));

//creo la inversion de dependencia
builder.Services.AddScoped<ICuentaService, CuentaService>();

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
