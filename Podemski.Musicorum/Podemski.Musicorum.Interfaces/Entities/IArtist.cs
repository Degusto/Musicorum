using System.Collections.Generic;

namespace Podemski.Musicorum.Interfaces.Entities
{
    public interface IArtist : IEntity
    {
        string Name { get; set; }

        IEnumerable<IAlbum> Albums { get; }
    }
}
