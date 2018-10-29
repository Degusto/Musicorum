using Podemski.Musicorum.Common.Enums;

namespace Podemski.Musicorum.Application.SearchCriterias
{
    public class SearchCriteria
    {
        private string _name;
        private Genre? _genre;

        public string Name
        {
            get => _name ?? string.Empty;
            set => _name = value;
        }

        public Genre Genre
        {
            get => _genre ?? Genre.All;
            set => _genre = value;
        }

        public bool? IsDigital { get; }

        public bool? IsForeign { get; }
    }
}