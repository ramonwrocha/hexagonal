using System.Text.RegularExpressions;

namespace Domain.Entities.ValueObjects;

public class Email
{
    public string Value { get; }

    private readonly Regex _emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public Email(string value)
    {
        if (!IsValid(value))
        {
            throw new ArgumentException("Email no válido");
        }

        Value = value;
    }

    private bool IsValid(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && _emailRegex.IsMatch(email);
    }
}


