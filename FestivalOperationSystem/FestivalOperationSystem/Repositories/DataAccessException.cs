namespace FestivalOperationSystem.Repositories
{
    /// <summary>
    /// Thrown when the database cannot be reached or rejects a command.
    /// It wraps the SQL Server exception so the layers above never depend on SQL Server types.
    /// </summary>
    public class DataAccessException : Exception
    {
        public DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
