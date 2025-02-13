using Application.Booking.Ports;
using Application.Booking.Validators;
using Application.Guest.Ports;
using Application.Guest.Validators;
using Application.Room;
using Application.Room.Ports;
using Data.DataAccess;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Application.Booking.Adapters;
using Application.Guest.Adapters;
using Application.Payment.Ports;
using Data.Adapters;
using Microsoft.Extensions.Options;
using Payment.Application.Adapters;
using Payment.Application.Adapters.PayPal;

namespace Api.IoC;

public static class IoCConfig
{
    public static IServiceCollection RegisterIoCContainer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        RegisteredServices(serviceCollection);
        RegisterRepositories(serviceCollection);
        RegisterData(serviceCollection, configuration);
        RegisterValidators(serviceCollection);
        RegisterExternalServices(serviceCollection);
        
        return serviceCollection;
    }

    private static void RegisterExternalServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPaymentProcessorFactory, PaymentProcessorFactory>();
        serviceCollection.AddOptions<IOptions<PayPalConfiguration>>();
    }

    private static void RegisterValidators(IServiceCollection serviceCollection)
    {
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
        serviceCollection.AddValidatorsFromAssemblyContaining<CreateBookingValidator>();
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
        serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
        serviceCollection.AddScoped<IGuestRepository, GuestRepository>();
        serviceCollection.AddScoped<IBookingRepository, BookingRepository>();
    }

    private static void RegisteredServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRoomService, RoomService>();
        serviceCollection.AddScoped<IGuestService, GuestService>();
        serviceCollection.AddScoped<IBookingService, BookingService>();
        serviceCollection.AddScoped<IPaymentService, PayPalService>();
    }
}
