using Ninject.Modules;
using Podemski.Musicorum.Interfaces.Services;
using Podemski.Musicorum.UI.Services;
using Podemski.Musicorum.UI.ViewModels;
using Podemski.Musicorum.UI.Views;

namespace Podemski.Musicorum.UI.Bootstrap
{
    public sealed class UiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IViewService>().To<ViewService>();
            Bind<MainViewModel>().ToSelf();
            Bind<ArtistViewModel>().ToSelf();
            Bind<AlbumViewModel>().ToSelf();
            Bind<TrackViewModel>().ToSelf();
            Bind<MainWindow>().ToSelf();
            Bind<AlbumPage>().ToSelf();
            Bind<ArtistPage>().ToSelf();
            Bind<TrackPage>().ToSelf();
        }
    }
}
