using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    public sealed class Track : ITrack
    {
        private IAlbum _album;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        public int AlbumId { get; set; }

        [NotMapped]
        public IAlbum Album
        {
            get => _album;
            set
            {
                _album = value;

                AlbumId = _album?.Id ?? 0;
            }
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public override string ToString() => Id.ToString();

        //public override string ToString() => $"{Album.Artist.Name} - {Album.Title} - {Title}";
    }
}