using FestivalOperationSystem.Controllers;
using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Views
{
    /// <summary>
    /// Main window (View in MVC). Shows the list of people with a menu bar, a role filter
    /// and a PersonID box for editing or deleting by ID.
    /// Every event handler only collects input, calls the controller and shows the result.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly PersonController _controller;

        /// <summary>Creates the main window; the controller is passed in by Program.</summary>
        public MainForm(PersonController controller)
        {
            InitializeComponent();
            _controller = controller;

            // Role filter: "All" first, then one entry per role.
            RoleComboBox.Items.Add("All");
            foreach (PersonRole role in Enum.GetValues<PersonRole>())
            {
                RoleComboBox.Items.Add(role);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Selecting "All" fires RoleComboBox_SelectedIndexChanged, which loads the list.
            RoleComboBox.SelectedIndex = 0;
        }

        /// <summary>Reloads the grid for the selected role.</summary>
        private void LoadPeople()
        {
            OperationResult<List<Person>> result = _controller.GetPeople(GetSelectedRole());
            PeopleDataGridView.Rows.Clear();
            if (!result.Success)
            {
                StatusLabel.Text = "Could not load records.";
                ShowError(result.Message);
                return;
            }

            // Polymorphism: GetRoleDetails() returns the right text for each subclass,
            // so this loop never needs to check which kind of person it has.
            foreach (Person person in result.Value)
            {
                PeopleDataGridView.Rows.Add(person.PersonId, person.Name, person.Role,
                    person.Telephone, person.Email, person.GetRoleDetails());
            }
            StatusLabel.Text = result.Value.Count == 0 ? "No records found." : $"{result.Value.Count} record(s)";
        }

        /// <summary>The role chosen in the filter, or null for "All".</summary>
        private PersonRole? GetSelectedRole()
        {
            return RoleComboBox.SelectedItem is PersonRole role ? role : null;
        }

        /// <summary>Opens the add dialog and refreshes the list if a record was saved.</summary>
        private void AddPerson()
        {
            using PersonForm form = new PersonForm(_controller);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadPeople();
            }
        }

        /// <summary>Opens the edit dialog for the ID in the PersonID box.</summary>
        private void EditPerson()
        {
            int personId = (int)PersonIdNumericUpDown.Value;
            OperationResult<PersonInput> result = _controller.GetPersonInput(personId);
            if (!result.Success)
            {
                ShowError(result.Message);
                return;
            }

            using PersonForm form = new PersonForm(_controller, personId, result.Value);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                LoadPeople();
            }
        }

        /// <summary>Soft deletes the person in the PersonID box after asking for confirmation.</summary>
        private void DeletePerson()
        {
            int personId = (int)PersonIdNumericUpDown.Value;
            OperationResult<Person> found = _controller.GetPerson(personId);
            if (!found.Success)
            {
                ShowError(found.Message);
                return;
            }

            DialogResult answer = MessageBox.Show(this,
                $"Delete {found.Value}?\n\nThe record will move to View > Deleted records and can be restored later.",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            OperationResult result = _controller.DeletePerson(personId);
            if (result.Success)
            {
                ShowInfo(result.Message);
            }
            else
            {
                ShowError(result.Message);
            }
            LoadPeople();
        }

        private void ShowInfo(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(this, message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ----- Event handlers: each one forwards to a method above -----

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPeople();
        }

        private void PeopleDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Clicking a row copies its ID into the PersonID box.
            // SelectedRows is used because CurrentRow still points at the old row while this event runs.
            if (PeopleDataGridView.SelectedRows.Count > 0
                && PeopleDataGridView.SelectedRows[0].Cells[IdColumn.Index].Value is int personId)
            {
                PersonIdNumericUpDown.Value = personId;
            }
        }

        private void PeopleDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditPerson();
            }
        }

        private void AddButton_Click(object sender, EventArgs e) => AddPerson();
        private void EditButton_Click(object sender, EventArgs e) => EditPerson();
        private void DeleteButton_Click(object sender, EventArgs e) => DeletePerson();
        private void AddMenuItem_Click(object sender, EventArgs e) => AddPerson();
        private void EditMenuItem_Click(object sender, EventArgs e) => EditPerson();
        private void DeleteMenuItem_Click(object sender, EventArgs e) => DeletePerson();

        // View menu: each item selects the matching entry in the role filter.
        private void AllRecordsMenuItem_Click(object sender, EventArgs e) => RoleComboBox.SelectedIndex = 0;
        private void PerformersMenuItem_Click(object sender, EventArgs e) => RoleComboBox.SelectedItem = PersonRole.Performer;
        private void CrewMenuItem_Click(object sender, EventArgs e) => RoleComboBox.SelectedItem = PersonRole.Crew;
        private void VendorsMenuItem_Click(object sender, EventArgs e) => RoleComboBox.SelectedItem = PersonRole.Vendor;

        private void DeletedRecordsMenuItem_Click(object sender, EventArgs e)
        {
            using DeletedRecordsForm form = new DeletedRecordsForm(_controller);
            form.ShowDialog(this);
            // Restored records must reappear in the main list.
            LoadPeople();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
