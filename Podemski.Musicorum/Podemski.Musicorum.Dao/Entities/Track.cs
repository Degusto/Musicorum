using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    internal sealed class Track : ITrack
    {
        public int Id { get; internal set; }

        public IAlbum Album { get; internal set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public override string ToString() => $"{Album.Artist.Name} - {Album.Title} - {Title}";
    }
}