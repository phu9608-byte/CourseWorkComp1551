using FestivalOperationSystem.Controllers;
using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Views
{
    /// <summary>
    /// Window listing soft-deleted records, with a Restore button (View in MVC).
    /// </summary>
    public partial class DeletedRecordsForm : Form
    {
        private readonly PersonController _controller;

        /// <summary>Creates the window; the controller comes from the main form.</summary>
        public DeletedRecordsForm(PersonController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        /// <summary>Reloads the list of deleted records.</summary>
        private void LoadDeletedPeople()
        {
            OperationResult<List<Person>> result = _controller.GetDeletedPeople();
            DeletedDataGridView.Rows.Clear();
            if (!result.Success)
            {
                SummaryLabel.Text = "Could not load deleted records.";
                MessageBox.Show(this, result.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Person person in result.Value)
            {
                DeletedDataGridView.Rows.Add(person.PersonId, person.Name, person.Role, person.Email,
                    person.DeletedAt?.ToString("dd/MM/yyyy HH:mm") ?? string.Empty);
            }
            SummaryLabel.Text = result.Value.Count == 0
                ? "No deleted records."
                : $"{result.Value.Count} deleted record(s). Select one and click Restore.";
        }

        private void DeletedRecordsForm_Load(object sender, EventArgs e)
        {
            LoadDeletedPeople();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow? row = DeletedDataGridView.CurrentRow;
            if (row?.Cells[IdColumn.Index].Value is not int personId)
            {
                MessageBox.Show(this, "Select a record to restore first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string name = row.Cells[NameColumn.Index].Value?.ToString() ?? string.Empty;
            DialogResult answer = MessageBox.Show(this, $"Restore #{personId} {name}?", "Confirm restore",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            OperationResult result = _controller.RestorePerson(personId);
            MessageBox.Show(this, result.Message, Text, MessageBoxButtons.OK,
                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            LoadDeletedPeople();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
