namespace FestivalOperationSystem.Models
{
    /// <summary>
    /// A food or merchandise stall at the festival.
    /// Adds a stall name and product categories to the shared Person fields (inheritance).
    /// The shared Name field holds the contact person's name.
    /// </summary>
    public class Vendor : Person
    {
        /// <summary>Longest category name the Categories.CategoryName column can hold.</summary>
        public const int MaxCategoryLength = 50;

        private string _stallName = string.Empty;
        private List<string> _categories = new List<string>();

        /// <summary>Creates a vendor; every value is checked by its property or setter.</summary>
        public Vendor(string name, string telephone, string email, string stallName, IEnumerable<string> categories)
            : base(name, telephone, email)
        {
            StallName = stallName;
            SetCategories(categories);
        }

        /// <inheritdoc />
        public override PersonRole Role => PersonRole.Vendor;

        /// <summary>Name of the stall. Required, at most 100 characters.</summary>
        public string StallName
        {
            get => _stallName;
            set => _stallName = RequireText(value, "Stall name", MaxNameLength);
        }

        /// <summary>
        /// Product categories sold at the stall. Read-only from outside the class;
        /// use <see cref="SetCategories"/> to replace them.
        /// </summary>
        public IReadOnlyList<string> Categories => _categories.AsReadOnly();

        /// <summary>Replaces the category list after trimming and checking each name.</summary>
        public void SetCategories(IEnumerable<string> categories)
        {
            _categories = CleanNames(categories, "Category", MaxCategoryLength);
        }

        /// <inheritdoc />
        public override string GetRoleDetails()
        {
            return $"Stall: {StallName} | Categories: {string.Join(", ", _categories)}";
        }
    }
}
