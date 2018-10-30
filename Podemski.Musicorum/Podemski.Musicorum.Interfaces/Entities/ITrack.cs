namespace Podemski.Musicorum.Interfaces.Entities
{
    public interface ITrack
    {
        int Id { get; }

        IAlbum Album { get; }

        string Title { get; }

        string Description { get; }
    }
}
