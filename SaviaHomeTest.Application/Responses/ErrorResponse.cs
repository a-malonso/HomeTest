namespace SaviaHomeTest.Application.Responses;

public class ErrorResponse<T> : Response<T> where T : class
{
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
    public ErrorResponse(string message, T data, IEnumerable<string> errors) : base(message, data)
    {
        Success = false;
        Errors = errors;
    }

    public ErrorResponse(string message, T data) : base(message, data)
    {
        Success = false;
    }
}