using System.Text.RegularExpressions;

namespace FestivalOperationSystem.Models
{
    /// <summary>
    /// Base class for everyone involved in running the festival.
    /// It holds the fields every role shares and checks each value before storing it,
    /// so a Person object can never be in an invalid state (encapsulation).
    /// </summary>
    public abstract class Person
    {
        /// <summary>Longest name the People.Name column can hold.</summary>
        public const int MaxNameLength = 100;

        // Simple shape check: something@something.something, no spaces.
        private static readonly Regex EmailPattern = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        // Optional leading +, then 7 to 15 digits (spaces and dashes are removed first).
        private static readonly Regex TelephonePattern = new Regex(@"^\+?\d{7,15}$");

        private int _personId;
        private string _name = string.Empty;
        private string _telephone = string.Empty;
        private string _email = string.Empty;

        /// <summary>
        /// Creates a person with the shared contact details.
        /// Each value goes through its property so the same checks apply.
        /// </summary>
        protected Person(string name, string telephone, string email)
        {
            Name = name;
            Telephone = telephone;
            Email = email;
        }

        /// <summary>
        /// Database ID. It is 0 for a person who has not been saved yet;
        /// the repository sets the real ID after inserting the record.
        /// </summary>
        public int PersonId
        {
            get => _personId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Person ID cannot be negative.");
                }
                _personId = value;
            }
        }

        /// <summary>Full name. Required, at most 100 characters.</summary>
        public string Name
        {
            get => _name;
            set => _name = RequireText(value, "Name", MaxNameLength);
        }

        /// <summary>
        /// Phone number as typed by the user. It must contain 7 to 15 digits;
        /// a leading +, spaces and dashes are allowed.
        /// </summary>
        public string Telephone
        {
            get => _telephone;
            set
            {
                string telephone = RequireText(value, "Telephone", 20);
                string digitsOnly = telephone.Replace(" ", "").Replace("-", "");
                if (!TelephonePattern.IsMatch(digitsOnly))
                {
                    throw new ArgumentException("Telephone must contain 7 to 15 digits (a leading +, spaces and dashes are allowed).");
                }
                _telephone = telephone;
            }
        }

        /// <summary>
        /// Email address, stored in lower case so that "A@x.com" and "a@x.com" count as the same address.
        /// </summary>
        public string Email
        {
            get => _email;
            set
            {
                string email = RequireText(value, "Email", 255).ToLowerInvariant();
                if (!EmailPattern.IsMatch(email))
                {
                    throw new ArgumentException("Email is not in a valid format, for example name@example.com.");
                }
                _email = email;
            }
        }

        /// <summary>True when the record has been soft deleted (moved to the deleted records list).</summary>
        public bool IsDeleted { get; private set; }

        /// <summary>When the record was soft deleted, or null if it is active.</summary>
        public DateTime? DeletedAt { get; private set; }

        /// <summary>The role of this person. Each subclass returns its own value.</summary>
        public abstract PersonRole Role { get; }

        /// <summary>
        /// Short text describing the role-specific fields, shown in the Details column.
        /// Each subclass overrides it (polymorphism), so the forms never need to check the type.
        /// </summary>
        public abstract string GetRoleDetails();

        /// <summary>
        /// Estimated cost of this person to the festival. People with no cost return 0;
        /// performers and crew override it.
        /// </summary>
        public virtual decimal EstimateCost()
        {
            return 0m;
        }

        /// <summary>
        /// Records the soft delete state loaded from the database.
        /// A null date means the record is active.
        /// </summary>
        public void SetDeletionState(DateTime? deletedAt)
        {
            IsDeleted = deletedAt.HasValue;
            DeletedAt = deletedAt;
        }

        /// <summary>One-line summary used in confirmation messages, e.g. "#3 Mark Davis (Crew)".</summary>
        public override string ToString()
        {
            return $"#{PersonId} {Name} ({Role})";
        }

        /// <summary>
        /// Trims a text value and rejects it if it is empty or longer than the limit.
        /// Shared by this class and its subclasses.
        /// </summary>
        protected static string RequireText(string? value, string fieldName, int maxLength)
        {
            string text = (value ?? string.Empty).Trim();
            if (text.Length == 0)
            {
                throw new ArgumentException($"{fieldName} is required.");
            }
            if (text.Length > maxLength)
            {
                throw new ArgumentException($"{fieldName} cannot be longer than {maxLength} characters.");
            }
            return text;
        }

        /// <summary>
        /// Cleans a list of names (genres or categories): trims each one and rejects empty or over-long names.
        /// The required count is a business rule and is checked in the service layer.
        /// </summary>
        protected static List<string> CleanNames(IEnumerable<string> names, string fieldName, int maxLength)
        {
            List<string> cleaned = new List<string>();
            foreach (string name in names)
            {
                cleaned.Add(RequireText(name, fieldName, maxLength));
            }
            return cleaned;
        }
    }
}
