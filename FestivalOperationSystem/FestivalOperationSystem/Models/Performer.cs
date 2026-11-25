using System.Globalization;

namespace FestivalOperationSystem.Models
{
    /// <summary>
    /// An artist or DJ who plays at the festival.
    /// Adds a fee and a list of music genres to the shared Person fields (inheritance).
    /// </summary>
    public class Performer : Person
    {
        /// <summary>Longest genre name the Genres.GenreName column can hold.</summary>
        public const int MaxGenreLength = 50;

        private decimal _fee;
        private List<string> _genres = new List<string>();

        /// <summary>Creates a performer; every value is checked by its property or setter.</summary>
        public Performer(string name, string telephone, string email, decimal fee, IEnumerable<string> genres)
            : base(name, telephone, email)
        {
            Fee = fee;
            SetGenres(genres);
        }

        /// <inheritdoc />
        public override PersonRole Role => PersonRole.Performer;

        /// <summary>Fee paid to the performer for the festival. Cannot be negative.</summary>
        public decimal Fee
        {
            get => _fee;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fee cannot be negative.");
                }
                _fee = value;
            }
        }

        /// <summary>
        /// Music genres of the performer. Read-only from outside the class;
        /// use <see cref="SetGenres"/> to replace them.
        /// </summary>
        public IReadOnlyList<string> Genres => _genres.AsReadOnly();

        /// <summary>Replaces the genre list after trimming and checking each name.</summary>
        public void SetGenres(IEnumerable<string> genres)
        {
            _genres = CleanNames(genres, "Genre", MaxGenreLength);
        }

        /// <inheritdoc />
        public override string GetRoleDetails()
        {
            return $"Fee {Fee.ToString("N2", CultureInfo.CurrentCulture)} | Genres: {string.Join(", ", _genres)}";
        }

        /// <summary>A performer costs their fee.</summary>
        public override decimal EstimateCost()
        {
            return Fee;
        }
    }
}
