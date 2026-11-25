using FestivalOperationSystem.Models;
using FestivalOperationSystem.Repositories;
using FestivalOperationSystem.Services;

namespace FestivalOperationSystem.Controllers
{
    /// <summary>
    /// Controller in MVC. Each public method handles one user action from a form:
    /// it builds Model objects from the form's input, calls the service,
    /// and turns any error into an <see cref="OperationResult"/> with a readable message.
    /// It contains no SQL and no Windows Forms code, so the forms stay thin.
    /// </summary>
    public class PersonController
    {
        private readonly IPersonService _service;

        /// <summary>Creates the controller on top of the business layer.</summary>
        public PersonController(IPersonService service)
        {
            _service = service;
        }

        /// <summary>Active people for the main list; role = null means all roles.</summary>
        public OperationResult<List<Person>> GetPeople(PersonRole? role)
        {
            return Run(() => _service.GetPeople(role));
        }

        /// <summary>Looks up an active person, used before editing or deleting by PersonID.</summary>
        public OperationResult<Person> GetPerson(int personId)
        {
            return Run(() => _service.GetPerson(personId));
        }

        /// <summary>
        /// Looks up an active person and returns their values as a <see cref="PersonInput"/>,
        /// ready to fill the edit form. Doing the conversion here keeps type checks out of the form.
        /// </summary>
        public OperationResult<PersonInput> GetPersonInput(int personId)
        {
            return Run(() => ToInput(_service.GetPerson(personId)));
        }

        /// <summary>Adds a new person from the form input and returns the new ID.</summary>
        public OperationResult<int> AddPerson(PersonInput input)
        {
            OperationResult<int> result = Run(() => _service.AddPerson(BuildPerson(input)));
            return result.Success
                ? OperationResult<int>.Ok(result.Value, $"Record added with PersonID {result.Value}.")
                : result;
        }

        /// <summary>Saves changes to an existing person from the form input.</summary>
        public OperationResult UpdatePerson(int personId, PersonInput input)
        {
            return Run(() =>
            {
                Person person = BuildPerson(input);
                person.PersonId = personId;
                _service.UpdatePerson(person);
                return $"Record #{personId} updated.";
            });
        }

        /// <summary>Soft deletes a person (the record moves to the deleted records list).</summary>
        public OperationResult DeletePerson(int personId)
        {
            return Run(() =>
            {
                _service.DeletePerson(personId);
                return $"Record #{personId} deleted. It can be restored from View > Deleted records.";
            });
        }

        /// <summary>Soft-deleted people for the deleted records window.</summary>
        public OperationResult<List<Person>> GetDeletedPeople()
        {
            return Run(() => _service.GetDeletedPeople());
        }

        /// <summary>Brings a soft-deleted person back to the main list.</summary>
        public OperationResult RestorePerson(int personId)
        {
            return Run(() =>
            {
                _service.RestorePerson(personId);
                return $"Record #{personId} restored.";
            });
        }

        /// <summary>
        /// Checks an email as soon as the user leaves the Email box, so a duplicate is reported early.
        /// Pass excludePersonId = 0 when adding, or the person's own ID when editing.
        /// </summary>
        public OperationResult CheckEmail(string email, int excludePersonId)
        {
            return Run(() =>
            {
                _service.CheckEmailAvailable(email, excludePersonId);
                return string.Empty;
            });
        }

        /// <summary>
        /// Creates the right Person subclass from the form input.
        /// The constructors and properties check every value (encapsulation),
        /// so invalid input becomes an ArgumentException here.
        /// </summary>
        private static Person BuildPerson(PersonInput input)
        {
            return input.Role switch
            {
                PersonRole.Performer => new Performer(input.Name, input.Telephone, input.Email,
                    input.Fee, input.Genres),
                PersonRole.Crew => new Crew(input.Name, input.Telephone, input.Email,
                    input.HourlyRate, input.EmploymentType, input.WeeklyHours),
                _ => new Vendor(input.Name, input.Telephone, input.Email,
                    input.StallName, input.Categories)
            };
        }

        /// <summary>The reverse of <see cref="BuildPerson"/>: copies a person's values into a PersonInput.</summary>
        private static PersonInput ToInput(Person person)
        {
            PersonInput input = new PersonInput
            {
                Role = person.Role,
                Name = person.Name,
                Telephone = person.Telephone,
                Email = person.Email
            };
            switch (person)
            {
                case Performer performer:
                    input.Fee = performer.Fee;
                    input.Genres = performer.Genres.ToList();
                    break;
                case Crew crew:
                    input.HourlyRate = crew.HourlyRate;
                    input.EmploymentType = crew.EmploymentType;
                    input.WeeklyHours = crew.WeeklyHours;
                    break;
                case Vendor vendor:
                    input.StallName = vendor.StallName;
                    input.Categories = vendor.Categories.ToList();
                    break;
            }
            return input;
        }

        /// <summary>
        /// Runs an action and converts the expected exceptions into a failed result,
        /// so the forms only ever deal with <see cref="OperationResult"/>.
        /// </summary>
        private static OperationResult<T> Run<T>(Func<T> action)
        {
            try
            {
                T value = action();
                // When the action returns a message (string), use it as the success message.
                return OperationResult<T>.Ok(value, value as string ?? string.Empty);
            }
            catch (ArgumentException ex)        // invalid value rejected by a Model class
            {
                return OperationResult<T>.Fail(ex.Message);
            }
            catch (BusinessRuleException ex)    // business rule broken, e.g. duplicate email
            {
                return OperationResult<T>.Fail(ex.Message);
            }
            catch (NotFoundException ex)        // PersonID does not exist or is in the wrong state
            {
                return OperationResult<T>.Fail(ex.Message);
            }
            catch (DataAccessException ex)      // database unreachable or command rejected
            {
                return OperationResult<T>.Fail(ex.Message);
            }
        }
    }
}
