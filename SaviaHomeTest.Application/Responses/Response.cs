namespace SaviaHomeTest.Application.Responses;

/// <summary>
/// Custom response object
/// </summary>
/// <typeparam name="T"></typeparam>
public class Response<T>
{
    /// <summary>
    /// True if request was ok, otherwise false
    /// </summary>
    public bool Success { get; set; } = true;

    /// <summary>
    /// Custom message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Data object that comes with the response
    /// </summary>
    public T? Data { get; set; }

    public Response(string message, T data)
    {
        Message = message;
        Data = data;
    }
}
