using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Artist : IArtist
    {
        public Artist()
        {
            Albums = Enumerable.Empty<IAlbum>();
        }

        public int Id { get; internal set; }

        public string Name { get; set; }

        public IEnumerable<IAlbum> Albums { get; internal set; }

        public override string ToString() => Name;
    }
}