namespace Application.Base;

public abstract class ResponseBase<T>
{
    public bool Success { get; set; } = true;

    public string MessageError { get; set; } = string.Empty;

    public T? Data { get; set; } = default;
}
