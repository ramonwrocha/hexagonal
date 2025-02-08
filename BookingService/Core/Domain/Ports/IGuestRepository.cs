using Domain.Entities;

namespace Domain.Ports;

public interface IGuestRepository
{
    Task<GuestEntity> Get(int id);

    Task<GuestEntity> GetByDocument(string documentNumber);

    Task<int> Create(GuestEntity guest);
}
