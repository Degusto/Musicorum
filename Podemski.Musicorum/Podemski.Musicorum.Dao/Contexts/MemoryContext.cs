using System.Collections.Generic;
using System.Linq;

using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao.Contexts
{
    internal sealed class MemoryContext : BaseContext
    {
        public override void SaveChanges()
        {
            foreach (var artist in Artists.Cast<Artist>())
            {
                if (artist.Id == 0)
                {
                    artist.Id = Artists.Max(x => x.Id);
                }
            }

            foreach (var album in Albums.Cast<Album>())
            {
                if (album.Id == 0)
                {
                    album.Id = Albums.Max(x => x.Id);
                }
            }

            foreach (var tracks in Tracks.Cast<Track>())
            {
                if (tracks.Id == 0)
                {
                    tracks.Id = Tracks.Max(x => x.Id);
                }
            }
        }

        protected override void LoadContext()
        {
            var tracks = new List<Track>
            {
                new Track
                {
                    Id = 1,
                    Title = "Tytuł 1",
                    Description = "Opis tytułu 1"
                },
                new Track
                {
                    Id = 2,
                    Title = "Tytuł 2",
                    Description = "Opis tytułu 2"
                },
                new Track
                {
                    Id = 3,
                    Title = "Tytuł 3",
                    Description = "Opis tytułu 3"
                },
                new Track
                {
                    Id = 4,
                    Title = "Tytuł 4",
                    Description = "Opis tytułu 4"
                },
                new Track
                {
                    Id = 5,
                    Title = "Tytuł 5",
                    Description = "Opis tytułu 5"
                },
                new Track
                {
                    Id = 6,
                    Title = "Tytuł 6",
                    Description = "Opis tytułu 6"
                },
                new Track
                {
                    Id = 7,
                    Title = "Tytuł 7",
                    Description = "Opis tytułu 7"
                },
                new Track
                {
                    Id = 8,
                    Title = "Tytuł 8",
                    Description = "Opis tytułu 8"
                },
            };

            var albums = new List<Album>
            {
                new Album
                {
                    Id = 1,
                    Title = "Album 1",
                    Genre = Core.Enums.Genre.Blues
                },
                new Album
                {
                    Id = 2,
                    Title = "Album 2",
                    Genre = Core.Enums.Genre.Pop
                },
                new Album
                {
                    Id = 3,
                    Title = "Album 3",
                    Genre = Core.Enums.Genre.Trap
                },
                new Album
                {
                    Id = 4,
                    Title = "Album 4",
                    Genre = Core.Enums.Genre.Rap
                },
            };

            var artists = new List<Artist>
            {
                new Artist
                {
                    Id = 1,
                    Name = "Artysta 1",
                    Albums = new[]{albums[0], albums[1]}
                },
                new Artist
                {
                    Id = 2,
                    Name = "Artysta 2",
                    Albums = new[]{albums[2], albums[3]}
                },
            };

            albums[0].Artist = artists[0];
            albums[1].Artist = artists[0];
            albums[2].Artist = artists[1];
            albums[3].Artist = artists[1];

            tracks[0].Album = albums[0];
            tracks[1].Album = albums[0];
            tracks[2].Album = albums[1];
            tracks[3].Album = albums[1];
            tracks[4].Album = albums[2];
            tracks[5].Album = albums[2];
            tracks[6].Album = albums[3];
            tracks[7].Album = albums[3];

            foreach (var album in albums)
            {
                album.TrackList = tracks.Where(x => x.Album == album);
            }

            Artists = artists.Cast<IArtist>().ToList();
            Albums = albums.Cast<IAlbum>().ToList();
            Tracks = tracks.Cast<ITrack>().ToList();
        }
    }
}