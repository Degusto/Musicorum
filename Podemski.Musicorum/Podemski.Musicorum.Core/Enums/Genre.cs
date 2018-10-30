using System;

namespace Podemski.Musicorum.Core.Enums
{
    [Flags]
    public enum Genre
    {
        Rock = 1 << 0,
        Rap = 1 << 1,
        Trap = 1 << 2,
        Pop = 1 << 3,
        Jazz = 1 << 4,
        Blues = 1 << 5,
        DiscoPolo = 1 << 6,
        All = Rock | Rap | Trap | Pop | Jazz | Blues | DiscoPolo
    }
}
