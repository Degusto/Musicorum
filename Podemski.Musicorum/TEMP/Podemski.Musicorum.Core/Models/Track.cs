namespace Podemski.Musicorum.Core.Models
{
    public sealed class Track
    {
        public int Id { get; }

        public Album Album { get; }

        public string Title { get; }

        public string Description { get; }

        public string Url { get; }
    }
}