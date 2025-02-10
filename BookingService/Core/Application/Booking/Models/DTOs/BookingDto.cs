namespace Application.Booking.Models.Dtos;

public sealed class BookingDto
{
    public int Id { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public decimal TotalPrice { get; set; }

    public string RoomName{ get; set; }

    public ICollection<string> GuestDocuments { get; set; } = new List<string>();
}
