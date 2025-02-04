using Domain.Entities;

namespace Domain.Ports;

public interface IGuestRepository
{
    Task<GuestEntity> Get(int id);

    Task<int> Save(GuestEntity guest);
}
