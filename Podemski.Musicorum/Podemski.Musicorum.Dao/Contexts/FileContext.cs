using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

using Newtonsoft.Json;

using Podemski.Musicorum.Dao.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal sealed class FileContext : Context
    {
        private readonly string _fileName;

        internal FileContext(string fileName) => _fileName = fileName;

        internal override void SaveChanges()
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
            File.WriteAllText(_fileName, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        internal override void LoadContext()
        {
            Deserialize();

            FixRelations();
        }

        private void Deserialize()
        {
            if(!File.Exists(_fileName))
            {
                return;
            }

            var context = new { Artists = new List<Artist>(), Albums = new List<Album>(), Tracks = new List<Track>() };

            context = JsonConvert.DeserializeAnonymousType(File.ReadAllText(_fileName), context);

            Artists = context.Artists.ToList();
            Albums = context.Albums.ToList();
            Tracks = context.Tracks.ToList();
        }

        private void FixRelations()
        {
            foreach (var artist in Artists)
            {
                artist.Albums = Albums.Where(album => album.ArtistId == artist.Id);

                foreach (var album in artist.Albums.Cast<Album>())
                {
                    album.Artist = artist;
                }
            }

            foreach (var album in Albums)
            {
                album.TrackList = Tracks.Where(track => track.AlbumId == album.Id);

                foreach (var track in album.TrackList.Cast<Track>())
                {
                    track.Album = album;
                }
            }
        }
    }
}
