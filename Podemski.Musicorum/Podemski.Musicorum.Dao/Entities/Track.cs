using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    internal sealed class Track : ITrack
    {
        private IAlbum _album;

        [JsonProperty]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; internal set; }

        [JsonProperty]
        [Column]
        public int AlbumId { get; private set; }

        [JsonIgnore]
        [NotMapped]
        public IAlbum Album
        {
            get => _album;
            internal set
            {
                _album = value;

                AlbumId = _album?.Id ?? 0;
            }
        }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        public override string ToString() => $"{Album.Artist.Name} - {Album.Title} - {Title}";
    }
}