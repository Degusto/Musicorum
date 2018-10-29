using System.Collections.Generic;

namespace Podemski.Musicorum.Core.Models
{
    public sealed class Artist
    {
        public int Id { get; }

        public string Name { get; }

        public IEnumerable<Album> Albums { get; }
    }
}