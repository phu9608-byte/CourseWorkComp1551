namespace FestivalOperationSystem.Services
{
    /// <summary>
    /// Business rules from the coursework brief, kept in one place so they are easy to find and change.
    /// </summary>
    public static class BusinessRules
    {
        /// <summary>Every performer must have exactly this many different genres.</summary>
        public const int RequiredGenreCount = 2;

        /// <summary>Every vendor must have exactly this many different product categories.</summary>
        public const int RequiredCategoryCount = 3;
    }
}
