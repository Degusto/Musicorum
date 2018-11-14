using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;

namespace Podemski.Musicorum.Dao.Factories
{
    internal sealed class TrackFactory : ITrackFactory
    {
        public ITrack Create(IAlbum album, string title, string description)
        {
            return new Track
            {
                Album = album,
                Title = title,
                Description = description
            };
        }
    }
}
