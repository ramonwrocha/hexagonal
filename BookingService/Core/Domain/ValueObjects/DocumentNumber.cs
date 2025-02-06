using Domain.Enums;

namespace Domain.ValueObjects;

public sealed class DocumentNumber
{
    public string Number { get; set; }

    public DocumentType Type { get; set; }
}
