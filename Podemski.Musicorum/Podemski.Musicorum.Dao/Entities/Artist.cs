using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    internal sealed class Artist : IArtist
    {
        public Artist()
        {
            Albums = Enumerable.Empty<IAlbum>();
        }

        [JsonProperty]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<IAlbum> Albums { get; internal set; }

        public override string ToString() => Name;
    }
}