using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Podemski.Musicorum.Dao.Entities;

namespace Podemski.Musicorum.Dao.File
{
    internal sealed class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member.DeclaringType == typeof(Artist) && member.Name == nameof(Artist.Albums))
            {
                property.Ignored = true;
            }

            if (member.DeclaringType == typeof(Album) && member.Name == nameof(Album.Artist))
            {
                property.Ignored = true;
            }

            if (member.DeclaringType == typeof(Album) && member.Name == nameof(Album.Tracks))
            {
                property.Ignored = true;
            }

            if (member.DeclaringType == typeof(Track) && member.Name == nameof(Track.Album))
            {
                property.Ignored = true;
            }

            return property;
        }
    }
}
