using System.Windows.Controls;
using Podemski.Musicorum.UI.ViewModels;

namespace Podemski.Musicorum.UI.Views
{
    public partial class ArtistPage : Page
    {
        public ArtistPage(ArtistViewModel artistViewModel)
        {
            InitializeComponent();

            DataContext = artistViewModel;
        }
    }
}
