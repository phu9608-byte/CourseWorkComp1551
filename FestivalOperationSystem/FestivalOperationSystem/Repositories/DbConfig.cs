namespace FestivalOperationSystem.Repositories
{
    /// <summary>
    /// Database connection settings, kept in one place.
    /// To run on another SQL Server, change only the Server part of this string,
    /// e.g. "Server=.\SQLEXPRESS;..." for SQL Server Express.
    /// </summary>
    public static class DbConfig
    {
        public const string ConnectionString =
            @"Server=(localdb)\MSSQLLocalDB;Database=Comp1551Coursework;Integrated Security=true;TrustServerCertificate=true";
    }
}
