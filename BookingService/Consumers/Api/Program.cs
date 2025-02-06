using Application.Guest;
using Application.Guest.Ports;
using Data.DataAccess;
using Data.Guest;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region DB PostGres TODO:Create IoC
var connectionStringPostgres = builder.Configuration.GetValue<string>("ConnectionString:PostgresConnection");
builder.Services.AddDbContext<HotelBookingDbContext>(dbContextOptions =>
{
    dbContextOptions.UseNpgsql(connectionStringPostgres);
});
#endregion

builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
