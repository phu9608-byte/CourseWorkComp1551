using System.Globalization;

namespace FestivalOperationSystem.Models
{
    /// <summary>
    /// A stage, sound, lighting or security worker, or a volunteer.
    /// Adds pay and working hours to the shared Person fields (inheritance).
    /// </summary>
    public class Crew : Person
    {
        // Allowed weekly hours for each contract type, as set by the coursework brief.
        public const int FullTimeMinHours = 25;
        public const int FullTimeMaxHours = 40;
        public const int PartTimeMinHours = 1;
        public const int PartTimeMaxHours = 24;

        private decimal _hourlyRate;

        /// <summary>Creates a crew member; every value is checked by its property or setter.</summary>
        public Crew(string name, string telephone, string email, decimal hourlyRate,
            EmploymentType employmentType, int weeklyHours)
            : base(name, telephone, email)
        {
            HourlyRate = hourlyRate;
            SetEmployment(employmentType, weeklyHours);
        }

        /// <inheritdoc />
        public override PersonRole Role => PersonRole.Crew;

        /// <summary>Pay per hour. Must be greater than zero.</summary>
        public decimal HourlyRate
        {
            get => _hourlyRate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hourly rate must be greater than zero.");
                }
                _hourlyRate = value;
            }
        }

        /// <summary>FullTime or PartTime. Changed only through <see cref="SetEmployment"/>.</summary>
        public EmploymentType EmploymentType { get; private set; }

        /// <summary>Hours worked per week. Changed only through <see cref="SetEmployment"/>.</summary>
        public int WeeklyHours { get; private set; }

        /// <summary>
        /// Sets the contract type and weekly hours together.
        /// They are set as a pair because the valid hours depend on the type:
        /// changing PartTime 10h to FullTime 30h one field at a time would fail half-way.
        /// </summary>
        public void SetEmployment(EmploymentType employmentType, int weeklyHours)
        {
            int min = GetMinHours(employmentType);
            int max = GetMaxHours(employmentType);
            if (weeklyHours < min || weeklyHours > max)
            {
                throw new ArgumentException($"{employmentType} crew must work between {min} and {max} hours per week.");
            }
            EmploymentType = employmentType;
            WeeklyHours = weeklyHours;
        }

        /// <summary>Lowest allowed weekly hours for a contract type.</summary>
        public static int GetMinHours(EmploymentType employmentType)
        {
            return employmentType == EmploymentType.FullTime ? FullTimeMinHours : PartTimeMinHours;
        }

        /// <summary>Highest allowed weekly hours for a contract type.</summary>
        public static int GetMaxHours(EmploymentType employmentType)
        {
            return employmentType == EmploymentType.FullTime ? FullTimeMaxHours : PartTimeMaxHours;
        }

        /// <inheritdoc />
        public override string GetRoleDetails()
        {
            return $"{EmploymentType}, {WeeklyHours} h/week at {HourlyRate.ToString("N2", CultureInfo.CurrentCulture)}/h";
        }

        /// <summary>A crew member costs one week of pay: hourly rate times weekly hours.</summary>
        public override decimal EstimateCost()
        {
            return HourlyRate * WeeklyHours;
        }
    }
}
