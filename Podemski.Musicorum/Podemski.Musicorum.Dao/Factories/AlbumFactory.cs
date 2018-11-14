using System;

using Podemski.Musicorum.Core.Enums;
using Podemski.Musicorum.Dao.Entities;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;

namespace Podemski.Musicorum.Dao.Factories
{
    internal sealed class AlbumFactory : IAlbumFactory
    {
        public IAlbum Create(IArtist artist, string title, Genre genre, bool isDigital, string description)
        {
            return new Album
            {
                Artist = artist,
                Title = title,
                Genre = genre,
                IsDigital = isDigital,
                Description = description
            };
        }
    }
}
