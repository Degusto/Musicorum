using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Track : ITrack
    {
        public int Id { get; set; }

        public IAlbum Album { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}