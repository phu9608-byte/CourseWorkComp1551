using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Services
{
    /// <summary>
    /// Business operations on people. Controllers call this interface;
    /// it enforces the business rules before anything reaches the database.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>Active people, either all of them (role = null) or only one role.</summary>
        List<Person> GetPeople(PersonRole? role);

        /// <summary>An active person by ID. Throws <see cref="NotFoundException"/> if there is none.</summary>
        Person GetPerson(int personId);

        /// <summary>Checks the rules, saves a new person and returns the new ID.</summary>
        int AddPerson(Person person);

        /// <summary>Checks the rules and saves changes to an existing active person.</summary>
        void UpdatePerson(Person person);

        /// <summary>Soft deletes an active person.</summary>
        void DeletePerson(int personId);

        /// <summary>All soft-deleted people.</summary>
        List<Person> GetDeletedPeople();

        /// <summary>Restores a soft-deleted person.</summary>
        void RestorePerson(int personId);

        /// <summary>
        /// Throws <see cref="BusinessRuleException"/> if the email already belongs to someone else.
        /// Use excludePersonId = 0 when adding, or the person's own ID when editing.
        /// </summary>
        void CheckEmailAvailable(string email, int excludePersonId);
    }
}
