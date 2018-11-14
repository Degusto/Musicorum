using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Factories
{
    public interface IAlbumFactory
    {
        IAlbum Create(IArtist artist, string title, Genre genre, bool isDigital, string description);
    }
}
