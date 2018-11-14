using Ninject.Modules;

using Podemski.Musicorum.Dao.Contexts;
using Podemski.Musicorum.Dao.Factories;
using Podemski.Musicorum.Dao.Repositories;
using Podemski.Musicorum.Interfaces.Factories;
using Podemski.Musicorum.Interfaces.Repositories;

namespace Podemski.Musicorum.Dao
{
    public sealed class DaoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<IArtistRepository>().To<ArtistRepository>();
            Bind<ITrackRepository>().To<TrackRepository>();
            Bind<IArtistFactory>().To<ArtistFactory>();
            Bind<IAlbumFactory>().To<AlbumFactory>();
            Bind<ITrackFactory>().To<TrackFactory>();

#warning Trzeba wyciągnąć z pliku konfiguracyjnego
            Bind<Context>().To<MemoryContext>().InSingletonScope();
        }
    }
}
