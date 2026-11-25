namespace FestivalOperationSystem.Services
{
    /// <summary>
    /// Thrown when a request breaks a business rule, for example a duplicate email
    /// or the wrong number of genres. The message is written to be shown to the user.
    /// </summary>
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message)
            : base(message)
        {
        }
    }
}
