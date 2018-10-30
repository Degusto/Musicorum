using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface IViewService
    {
        void ShowView(IArtist artist);
        void ShowView(IAlbum album);
        void ShowView(ITrack track);
    }
}
