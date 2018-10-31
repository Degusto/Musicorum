namespace Podemski.Musicorum.Interfaces.Entities
{
    public interface ITrack : IEntity
    {
        IAlbum Album { get; }

        string Title { get; set; }

        string Description { get; set; }
    }
}
