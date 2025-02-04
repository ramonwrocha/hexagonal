using Data.DataAccess;
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
