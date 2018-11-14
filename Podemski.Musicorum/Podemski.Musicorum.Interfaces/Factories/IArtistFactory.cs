using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Interfaces.Factories
{
    public interface IArtistFactory
    {
        IArtist Create(string name);
    }
}
