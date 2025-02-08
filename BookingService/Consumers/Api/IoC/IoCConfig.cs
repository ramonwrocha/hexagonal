using Application.Guest;
using Application.Guest.Ports;
using Application.Guest.Validators;
using Application.Room;
using Application.Room.Ports;
using Data.DataAccess;
using Data.Guest;
using Data.Room;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace Api.IoC;

public static class IoCConfig
{
    public static IServiceCollection RegisterIoCContainer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        RegisteredServices(serviceCollection);
        RegisterRepositories(serviceCollection);
        RegisterData(serviceCollection, configuration);
        RegisterValidators(serviceCollection);

        return serviceCollection;
    }

    private static void RegisterValidators(IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
    }

    private static void RegisterData(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionStringPostgres = configuration.GetValue<string>("ConnectionString:PostgresConnection");
        serviceCollection.AddDbContext<HotelBookingDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseNpgsql(connectionStringPostgres);
        });
    }

    private static void RegisterRepositories(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGuestRepository, GuestRepository>();
        serviceCollection.AddScoped<IRoomRepository, RoomRepository>();

    }

    private static void RegisteredServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGuestService, GuestService>();
        serviceCollection.AddScoped<IRoomService, RoomService>();

    }
}
