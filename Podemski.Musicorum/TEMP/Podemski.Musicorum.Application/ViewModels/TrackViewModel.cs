namespace Podemski.Musicorum.Application.ViewModels
{
    public sealed class TrackViewModel
    {
        internal int Id { get; }

        public int AlbumId { get; }

        public string AlbumName { get; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}