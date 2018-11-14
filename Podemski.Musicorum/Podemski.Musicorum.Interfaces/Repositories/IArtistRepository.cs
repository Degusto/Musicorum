using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Repositories
{
    public interface IArtistRepository : IRepository<IArtist>
    {
        void AddAlbum(IArtist artist, IAlbum album);
    }
}
