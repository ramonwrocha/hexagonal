using Application.Guest.Models.Dtos;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Entities.ValueObjects;

namespace Application.Guest.Mappings;

public static class GuestMapper
{
    public static GuestDto Map(GuestEntity entity)
    {
        return new GuestDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Surname = entity.Surname,
            Email = entity.Email.Value,
            Type = entity.Type.ToString(),
            DocumentNumber = entity.Document.Number,
            DocumentType = entity.Document.Type.ToString()
        };
    }

    public static GuestEntity Map(GuestDto dto)
    {
        return new GuestEntity()
        {
            Id = dto.Id,
            Name = dto.Name,
            Surname = dto.Surname,
            Email = new Email(dto.Email),
            Type = Enum.TryParse<GuestType>(dto.Type, out var guestType) ? guestType : GuestType.Adult,
            Document = new DocumentNumber
            {
                Number = dto.DocumentNumber,
                Type = ParseDocumentType(dto.DocumentType)
            }
        };
    }

    private static DocumentType ParseDocumentType(string documentType)
    {
        return Enum.TryParse<DocumentType>(documentType, out var result) ? result : DocumentType.IDCard;
    }
}
