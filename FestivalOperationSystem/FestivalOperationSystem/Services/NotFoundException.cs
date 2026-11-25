namespace FestivalOperationSystem.Services
{
    /// <summary>
    /// Thrown when no record matches the requested PersonID
    /// (or the record exists but is in the wrong state, e.g. already deleted).
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message)
            : base(message)
        {
        }
    }
}
