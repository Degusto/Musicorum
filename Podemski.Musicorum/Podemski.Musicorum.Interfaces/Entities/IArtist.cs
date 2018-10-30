using System.Collections.Generic;

namespace Podemski.Musicorum.Interfaces.Entities
{
    public interface IArtist
    {
        int Id { get; set; }

        string Name { get; set; }

        IEnumerable<IAlbum> Albums { get; set; }
    }
}
