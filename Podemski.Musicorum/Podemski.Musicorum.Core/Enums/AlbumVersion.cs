using System.ComponentModel;

namespace Podemski.Musicorum.Core.Enums
{
    public enum AlbumVersion
    {
        [Description("---")]
        None,
        [Description("Cyfrowa")]
        Digital,
        [Description("Fizyczna")]
        Physical
    }
}
