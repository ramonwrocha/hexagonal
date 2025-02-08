using Domain.Entities;

namespace Domain.Ports;

public interface IBookingRepository
{
    Task<BookingEntity> Get(int id);

    Task<ICollection<BookingEntity>> GetByDocument(string email);

    Task<int> Create(BookingEntity guest);
}
