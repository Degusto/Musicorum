using Podemski.Musicorum.UI.ViewModels;

namespace Podemski.Musicorum.UI.Views
{
    public partial class AlbumPage
    {
        public AlbumPage(AlbumViewModel albumViewModel)
        {
            InitializeComponent();

            DataContext = albumViewModel;
        }
    }
}
