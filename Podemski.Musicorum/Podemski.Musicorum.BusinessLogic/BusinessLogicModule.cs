using Ninject.Modules;

using Podemski.Musicorum.BusinessLogic.Services;
using Podemski.Musicorum.Interfaces.Services;

namespace Podemski.Musicorum.BusinessLogic
{
    public sealed class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumService>().To<AlbumService>();
            Bind<IArtistService>().To<ArtistService>();
            Bind<ITrackService>().To<TrackService>();
            Bind<ISearchService>().To<SearchService>();
        }
    }
}