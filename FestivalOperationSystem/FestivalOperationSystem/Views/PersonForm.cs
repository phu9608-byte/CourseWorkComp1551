using FestivalOperationSystem.Controllers;
using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Views
{
    /// <summary>
    /// Dialog for adding a new person or editing an existing one (View in MVC).
    /// It only checks that required boxes are filled in; all other rules are checked
    /// by the Model and Service layers through the controller.
    /// </summary>
    public partial class PersonForm : Form
    {
        private readonly PersonController _controller;

        // 0 while adding a new record; the record's ID while editing.
        private readonly int _personId;

        /// <summary>Opens the dialog in "add" mode.</summary>
        public PersonForm(PersonController controller)
            : this(controller, 0, null)
        {
        }

        /// <summary>Opens the dialog in "edit" mode, filled with the current values.</summary>
        public PersonForm(PersonController controller, int personId, PersonInput? existing)
        {
            InitializeComponent();
            _controller = controller;
            _personId = personId;

            foreach (PersonRole role in Enum.GetValues<PersonRole>())
            {
                RoleComboBox.Items.Add(role);
            }
            foreach (EmploymentType type in Enum.GetValues<EmploymentType>())
            {
                EmploymentTypeComboBox.Items.Add(type);
            }
            EmploymentTypeComboBox.SelectedItem = EmploymentType.FullTime;

            if (existing == null)
            {
                Text = "Add new record";
                RoleComboBox.SelectedItem = PersonRole.Performer;
            }
            else
            {
                Text = $"Edit record #{personId}";
                FillFields(existing);
                // Changing the role of an existing record is not allowed.
                RoleComboBox.Enabled = false;
            }
        }

        /// <summary>The role currently chosen in the Role box.</summary>
        private PersonRole SelectedRole => (PersonRole)RoleComboBox.SelectedItem!;

        /// <summary>Puts the values of an existing person into the boxes.</summary>
        private void FillFields(PersonInput input)
        {
            RoleComboBox.SelectedItem = input.Role;
            NameTextBox.Text = input.Name;
            TelephoneTextBox.Text = input.Telephone;
            EmailTextBox.Text = input.Email;

            FeeNumericUpDown.Value = Math.Clamp(input.Fee, FeeNumericUpDown.Minimum, FeeNumericUpDown.Maximum);
            Genre1TextBox.Text = input.Genres.ElementAtOrDefault(0) ?? string.Empty;
            Genre2TextBox.Text = input.Genres.ElementAtOrDefault(1) ?? string.Empty;

            if (input.Role == PersonRole.Crew)
            {
                HourlyRateNumericUpDown.Value = Math.Clamp(input.HourlyRate, HourlyRateNumericUpDown.Minimum, HourlyRateNumericUpDown.Maximum);
                // Selecting the type first sets the allowed range for the hours box.
                EmploymentTypeComboBox.SelectedItem = input.EmploymentType;
                WeeklyHoursNumericUpDown.Value = Math.Clamp(input.WeeklyHours, WeeklyHoursNumericUpDown.Minimum, WeeklyHoursNumericUpDown.Maximum);
            }

            StallNameTextBox.Text = input.StallName;
            Category1TextBox.Text = input.Categories.ElementAtOrDefault(0) ?? string.Empty;
            Category2TextBox.Text = input.Categories.ElementAtOrDefault(1) ?? string.Empty;
            Category3TextBox.Text = input.Categories.ElementAtOrDefault(2) ?? string.Empty;
        }

        /// <summary>Collects the values from the boxes into a PersonInput for the controller.</summary>
        private PersonInput ReadInput()
        {
            return new PersonInput
            {
                Role = SelectedRole,
                Name = NameTextBox.Text,
                Telephone = TelephoneTextBox.Text,
                Email = EmailTextBox.Text,
                Fee = FeeNumericUpDown.Value,
                Genres = new List<string> { Genre1TextBox.Text, Genre2TextBox.Text },
                HourlyRate = HourlyRateNumericUpDown.Value,
                EmploymentType = (EmploymentType)EmploymentTypeComboBox.SelectedItem!,
                WeeklyHours = (int)WeeklyHoursNumericUpDown.Value,
                StallName = StallNameTextBox.Text,
                Categories = new List<string> { Category1TextBox.Text, Category2TextBox.Text, Category3TextBox.Text }
            };
        }

        /// <summary>
        /// Marks every empty required box with an error icon.
        /// Returns true when all required boxes for the chosen role are filled in.
        /// </summary>
        private bool CheckRequiredFields()
        {
            List<TextBox> required = new List<TextBox> { NameTextBox, TelephoneTextBox, EmailTextBox };
            if (SelectedRole == PersonRole.Performer)
            {
                required.AddRange(new[] { Genre1TextBox, Genre2TextBox });
            }
            else if (SelectedRole == PersonRole.Vendor)
            {
                required.AddRange(new[] { StallNameTextBox, Category1TextBox, Category2TextBox, Category3TextBox });
            }

            bool allFilled = true;
            foreach (TextBox box in required)
            {
                bool isEmpty = string.IsNullOrWhiteSpace(box.Text);
                InputErrorProvider.SetError(box, isEmpty ? "This field is required." : string.Empty);
                allFilled &= !isEmpty;
            }
            return allFilled;
        }

        /// <summary>
        /// Sets the allowed range of the weekly hours box.
        /// The order matters: NumericUpDown refuses a minimum above its current maximum.
        /// </summary>
        private void SetWeeklyHoursRange(int min, int max)
        {
            if (min > WeeklyHoursNumericUpDown.Maximum)
            {
                WeeklyHoursNumericUpDown.Maximum = max;
                WeeklyHoursNumericUpDown.Minimum = min;
            }
            else
            {
                WeeklyHoursNumericUpDown.Minimum = min;
                WeeklyHoursNumericUpDown.Maximum = max;
            }
        }

        // ----- Event handlers -----

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show only the box of fields that belongs to the chosen role.
            PerformerGroupBox.Visible = SelectedRole == PersonRole.Performer;
            CrewGroupBox.Visible = SelectedRole == PersonRole.Crew;
            VendorGroupBox.Visible = SelectedRole == PersonRole.Vendor;
        }

        private void EmploymentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FullTime allows 25-40 hours, PartTime 1-24; the box clamps its value automatically.
            EmploymentType type = (EmploymentType)EmploymentTypeComboBox.SelectedItem!;
            SetWeeklyHoursRange(Crew.GetMinHours(type), Crew.GetMaxHours(type));
        }

        private void EmailTextBox_Leave(object sender, EventArgs e)
        {
            // Report a duplicate email straight away instead of waiting for Save.
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                return;
            }
            OperationResult result = _controller.CheckEmail(EmailTextBox.Text, _personId);
            InputErrorProvider.SetError(EmailTextBox, result.Success ? string.Empty : result.Message);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!CheckRequiredFields())
            {
                return;
            }

            PersonInput input = ReadInput();
            OperationResult result = _personId == 0
                ? _controller.AddPerson(input)
                : _controller.UpdatePerson(_personId, input);

            if (!result.Success)
            {
                // Keep the dialog open with everything the user typed, so they can fix it.
                MessageBox.Show(this, result.Message, "Cannot save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(this, result.Message, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}
