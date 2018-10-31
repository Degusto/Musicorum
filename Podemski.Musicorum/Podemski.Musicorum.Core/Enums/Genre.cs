namespace Podemski.Musicorum.Core.Enums
{
    public enum Genre
    {
        Rock = 1,
        Rap = 2,
        Trap = 3,
        Pop = 4,
        Jazz = 5,
        Blues = 6,
        DiscoPolo = 7,
        Metal = 8,
        All = Rock | Rap | Trap | Pop | Jazz | Blues | DiscoPolo | Metal
    }
}