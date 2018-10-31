using Podemski.Musicorum.UI.ViewModels;

namespace Podemski.Musicorum.UI.Views
{
    public partial class TrackPage
    {
        public TrackPage(TrackViewModel trackViewModel)
        {
            InitializeComponent();

            DataContext = trackViewModel;
        }
    }
}
