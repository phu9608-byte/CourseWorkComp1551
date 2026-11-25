using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Repositories
{
    /// <summary>
    /// Everything the application can ask the database to do with people.
    /// The service layer depends on this interface, not on SQL Server directly.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>All active (not deleted) people, ordered by ID.</summary>
        List<Person> GetAll();

        /// <summary>Active people with the given role, ordered by ID.</summary>
        List<Person> GetByRole(PersonRole role);

        /// <summary>An active person by ID, or null if the ID does not exist or is deleted.</summary>
        Person? GetById(int personId);

        /// <summary>All soft-deleted people, most recently deleted first.</summary>
        List<Person> GetDeleted();

        /// <summary>
        /// The person (active or deleted) who owns this email address, or null.
        /// Deleted people are included because their email is still reserved.
        /// </summary>
        Person? FindByEmail(string email);

        /// <summary>Saves a new person with their role data and returns the new ID.</summary>
        int Add(Person person);

        /// <summary>Saves changes to an existing person, including genres or categories.</summary>
        void Update(Person person);

        /// <summary>Marks an active person as deleted. The rows are kept so they can be restored.</summary>
        void SoftDelete(int personId);

        /// <summary>Brings a soft-deleted person back to the active list.</summary>
        void Restore(int personId);
    }
}
