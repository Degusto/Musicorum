using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<IAlbum> Albums { get; set; }

        public override string ToString() => Id.ToString();
        //public override string ToString() => Name;
    }
}