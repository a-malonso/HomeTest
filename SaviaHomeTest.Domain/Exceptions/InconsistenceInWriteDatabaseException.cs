using SaviaHomeTest.Domain.constants;

namespace SaviaHomeTest.Domain.Exceptions;

public class InconsistenceInWriteDatabaseException : Exception
{
    public InconsistenceInWriteDatabaseException() : base(ExceptionMessages.InconsistenceInWriteDatabasesExceptionMessage) { }
}
