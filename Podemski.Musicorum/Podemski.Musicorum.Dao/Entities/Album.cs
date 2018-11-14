using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Entities
{
    internal sealed class Album : IAlbum
    {
        private IArtist _artist;

        internal Album()
        {
            TrackList = Enumerable.Empty<ITrack>();
        }

        [JsonProperty]
        public int Id { get; internal set; }

        [JsonProperty]
        internal int ArtistId { get; private set; }

        [JsonIgnore]
        public IArtist Artist
        {
            get => _artist;
            internal set
            {
                _artist = value;
                
                ArtistId = _artist?.Id ?? 0;
            }
        }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public Genre Genre { get; set; }

        [JsonProperty]
        public bool IsDigital { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonIgnore]
        public IEnumerable<ITrack> TrackList { get; internal set; }

        public override string ToString() => $"{Artist.Name} - {Title}";
    }
}