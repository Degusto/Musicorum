using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Album : IAlbum
    {
        private IArtist _artist;

        public Album()
        {
            Tracks = Enumerable.Empty<ITrack>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        public int ArtistId { get; set; }

        [NotMapped]
        public IArtist Artist
        {
            get => _artist;
            set
            {
                _artist = value;

                ArtistId = _artist?.Id ?? 0;
            }
        }

        public string Title { get; set; }

        public Genre Genre { get; set; }

        public bool IsDigital { get; set; }

        public string Description { get; set; }

        public IEnumerable<ITrack> Tracks { get; set; }


        public override string ToString() => Id.ToString();
        //public override string ToString() => $"{Artist.Name} - {Title}";
    }
}