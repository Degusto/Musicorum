using Podemski.Musicorum.Core.Enums;

namespace Podemski.Musicorum.Interfaces.SearchCriterias
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

        public AlbumVersion AlbumVersion { get; set; }
    }
}