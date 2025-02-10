using Domain.Entities.Enums;

namespace Domain.Entities.ValueObjects;

public sealed class DocumentNumber
{
    public string Number { get; set; }

    public DocumentType Type { get; set; }
}
