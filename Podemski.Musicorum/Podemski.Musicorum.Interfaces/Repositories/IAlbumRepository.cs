using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Repositories
{
    public interface IAlbumRepository : IRepository<IAlbum>
    {
        void AddTrack(IAlbum album, ITrack track);
    }
}
