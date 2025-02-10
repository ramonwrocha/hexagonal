namespace Application.Guest.Models.Dtos;    

public sealed record GuestDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public string Type { get; set; }

    public string DocumentNumber { get; set; }

    public string DocumentType { get; set; }
}
