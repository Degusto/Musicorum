using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.UI.Views
{
    public partial class ArtistWindow
    {
        private IArtist artist;

        public ArtistWindow(IArtist artist)
        {
            InitializeComponent();
        }
    }
}
