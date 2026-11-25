using FestivalOperationSystem.Models;

namespace FestivalOperationSystem.Controllers
{
    /// <summary>
    /// Raw values collected from the add / edit form, passed from the View to the Controller.
    /// Only the fields of the chosen role are used; the others are ignored.
    /// </summary>
    public class PersonInput
    {
        public PersonRole Role { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Performer
        public decimal Fee { get; set; }
        public List<string> Genres { get; set; } = new List<string>();

        // Crew
        public decimal HourlyRate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public int WeeklyHours { get; set; }

        // Vendor
        public string StallName { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
    }
}
