using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;

namespace Podemski.Musicorum.Dao.Factories
{
    internal sealed class ArtistFactory : IArtistFactory
    {
        public IArtist Create(string name)
        {
            return new Artist { Name = name };
        }
    }
}
