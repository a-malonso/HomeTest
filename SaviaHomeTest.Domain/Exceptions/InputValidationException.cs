using SaviaHomeTest.Domain.constants;

namespace SaviaHomeTest.Domain.Exceptions;

/// <summary>
/// Exception to catch input validation errors
/// </summary>
public class InputValidationException : Exception
{
    public IEnumerable<string> ValidationErrors { get; set; }
    public InputValidationException(IEnumerable<string> validationErrors) : base(ExceptionMessages.ValidationExceptionMessage)
    {
        ValidationErrors = validationErrors;
    }
}
