using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Artist : IArtist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IAlbum> Albums { get; set; }
    }
}