using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Factories
{
    public interface ITrackFactory
    {
        ITrack Create(IAlbum album, string title, string description);
    }
}
