using SaviaHomeTest.Domain.constants;

namespace SaviaHomeTest.Domain.Exceptions;

public class InconsistenceInReadDatabaseException : Exception
{
    public InconsistenceInReadDatabaseException() : base(ExceptionMessages.InconsistenceInReadDatabasesExceptionMessage) { }
}
