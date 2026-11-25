using System.Globalization;
using FestivalOperationSystem.Controllers;
using FestivalOperationSystem.Repositories;
using FestivalOperationSystem.Services;
using FestivalOperationSystem.Views;

namespace FestivalOperationSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Use British number and date formats (12.50, not 12,50) on every machine.
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");

            ApplicationConfiguration.Initialize();

            // Last safety net: any error that slips through is shown in a message box
            // instead of closing the application.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
                MessageBox.Show("An unexpected error occurred:\n\n" + e.Exception.Message,
                    "Festival Operations System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Wire the layers together: Repository -> Service -> Controller -> Form.
            IPersonRepository repository = new SqlPersonRepository(DbConfig.ConnectionString);
            IPersonService service = new PersonService(repository);
            PersonController controller = new PersonController(service);

            Application.Run(new MainForm(controller));
        }
    }
}
