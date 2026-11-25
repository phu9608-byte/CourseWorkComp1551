using FestivalOperationSystem.Models;
using FestivalOperationSystem.Repositories;

namespace FestivalOperationSystem.Services
{
    /// <summary>
    /// Business layer. Applies the rules that involve more than one object or the database
    /// (unique email, exact number of genres and categories, soft delete states)
    /// and then calls the repository. It never shows anything on screen.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        /// <summary>Creates the service on top of a repository.</summary>
        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc />
        public List<Person> GetPeople(PersonRole? role)
        {
            return role.HasValue ? _repository.GetByRole(role.Value) : _repository.GetAll();
        }

        /// <inheritdoc />
        public Person GetPerson(int personId)
        {
            // Deleted people are treated exactly like IDs that do not exist.
            Person? person = _repository.GetById(personId);
            if (person == null)
            {
                throw new NotFoundException($"Record not found: there is no active record with PersonID {personId}.");
            }
            return person;
        }

        /// <inheritdoc />
        public int AddPerson(Person person)
        {
            CheckEmailAvailable(person.Email, 0);
            CheckRoleRules(person);
            return _repository.Add(person);
        }

        /// <inheritdoc />
        public void UpdatePerson(Person person)
        {
            Person existing = GetPerson(person.PersonId);
            if (existing.Role != person.Role)
            {
                throw new BusinessRuleException("The role of a record cannot be changed. Delete it and add a new record instead.");
            }

            // Keeping your own email is fine; taking someone else's is not.
            CheckEmailAvailable(person.Email, person.PersonId);
            CheckRoleRules(person);
            _repository.Update(person);
        }

        /// <inheritdoc />
        public void DeletePerson(int personId)
        {
            GetPerson(personId);
            _repository.SoftDelete(personId);
        }

        /// <inheritdoc />
        public List<Person> GetDeletedPeople()
        {
            return _repository.GetDeleted();
        }

        /// <inheritdoc />
        public void RestorePerson(int personId)
        {
            bool isInDeletedList = _repository.GetDeleted().Any(person => person.PersonId == personId);
            if (!isInDeletedList)
            {
                throw new NotFoundException($"Record #{personId} is not in the deleted records list.");
            }
            _repository.Restore(personId);
        }

        /// <inheritdoc />
        public void CheckEmailAvailable(string email, int excludePersonId)
        {
            Person? owner = _repository.FindByEmail(email);
            if (owner == null || owner.PersonId == excludePersonId)
            {
                return;
            }

            // Deleted people keep their email, so restoring them can never create a duplicate.
            if (owner.IsDeleted)
            {
                throw new BusinessRuleException(
                    $"This email belongs to deleted record #{owner.PersonId} ({owner.Name}). Restore that record instead of adding a new one.");
            }
            throw new BusinessRuleException($"This email is already used by record #{owner.PersonId} ({owner.Name}).");
        }

        /// <summary>Checks the rules that depend on the role: exact, different genres or categories.</summary>
        private static void CheckRoleRules(Person person)
        {
            if (person is Performer performer)
            {
                CheckNameList(performer.Genres, BusinessRules.RequiredGenreCount, "genres");
            }
            else if (person is Vendor vendor)
            {
                CheckNameList(vendor.Categories, BusinessRules.RequiredCategoryCount, "product categories");
            }
        }

        /// <summary>The list must have exactly the required number of names, with no repeats (ignoring case).</summary>
        private static void CheckNameList(IReadOnlyList<string> names, int requiredCount, string label)
        {
            if (names.Count != requiredCount)
            {
                throw new BusinessRuleException($"Exactly {requiredCount} {label} are required.");
            }
            int distinctCount = names.Distinct(StringComparer.OrdinalIgnoreCase).Count();
            if (distinctCount != names.Count)
            {
                throw new BusinessRuleException($"The {label} must all be different.");
            }
        }
    }
}
