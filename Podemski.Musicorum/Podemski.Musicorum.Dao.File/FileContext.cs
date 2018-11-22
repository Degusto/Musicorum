using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using Podemski.Musicorum.Dao.Entities;

using FileHelpers = System.IO.File;

namespace Podemski.Musicorum.Dao.File
{
    public sealed class FileContext : Context
    {
        private string _fileName;
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings { Formatting = Formatting.Indented, ContractResolver = new CustomContractResolver() };

        public override void Initialize(string data) => _fileName = data;

        public override void SaveChanges()
        {
            foreach (var artist in Artists)
            {
                if (artist.Id == 0)
                {
                    artist.Id = Artists.Max(x => x.Id) + 1;
                }
            }

            foreach (var album in Albums)
            {
                if (album.Id == 0)
                {
                    album.Id = Albums.Max(x => x.Id) + 1;
                }
            }

            foreach (var tracks in Tracks)
            {
                if (tracks.Id == 0)
                {
                    tracks.Id = Tracks.Max(x => x.Id) + 1;
                }
            }

            Serialize();
        }

        private void Serialize()
        {
            FileHelpers.WriteAllText(_fileName, JsonConvert.SerializeObject(this, _jsonSettings));
        }

        public override void LoadContext()
        {
            Deserialize();

            FixRelations();
        }

        private void Deserialize()
        {
            if (!FileHelpers.Exists(_fileName))
            {
                return;
            }

            var context = new { Artists = new List<Artist>(), Albums = new List<Album>(), Tracks = new List<Track>() };

            context = JsonConvert.DeserializeAnonymousType(FileHelpers.ReadAllText(_fileName), context, _jsonSettings);

            Artists = context.Artists.ToList();
            Albums = context.Albums.ToList();
            Tracks = context.Tracks.ToList();
        }

        private void FixRelations()
        {
            foreach (var artist in Artists)
            {
                artist.Albums = Albums.Where(album => album.ArtistId == artist.Id).ToList();

                foreach (var album in artist.Albums.Cast<Album>())
                {
                    album.Artist = artist;
                }
            }

            foreach (var album in Albums)
            {
                album.Tracks = Tracks.Where(track => track.AlbumId == album.Id).ToList();

                foreach (var track in album.Tracks.Cast<Track>())
                {
                    track.Album = album;
                }
            }
        }
    }
}
