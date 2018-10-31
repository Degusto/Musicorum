using System.ComponentModel;

namespace Podemski.Musicorum.Core.Enums
{
    public enum ObjectType
    {
        [Description("Wszystkie")]
        All,
        [Description("Artyści")]
        Artist,
        [Description("Albumy")]
        Album,
        [Description("Utwory")]
        Track
    }
}
