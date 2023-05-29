namespace SaviaHomeTest.Domain.constants;

/// <summary>
/// Exception messages as constants
/// </summary>
public static class ExceptionMessages
{
    /// <summary>
    /// Message for InputValidationException.
    /// </summary>
    public const string ValidationExceptionMessage = "Sent data contains errors";

    /// <summary>
    /// Message for InconsistenceInDatabasesException.
    /// </summary>
    public const string InconsistenceInReadDatabasesExceptionMessage = "There has been an error synchronizing the databases. Read database is behind write database";

    /// <summary>
    /// Message for InconsistenceInDatabasesException.
    /// </summary>
    public const string InconsistenceInWriteDatabasesExceptionMessage = "There has been an error synchronizing the databases. Write database is behind write database";
}
