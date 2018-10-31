using Ninject.Modules;

using Podemski.Musicorum.Dao.Contexts;
using Podemski.Musicorum.Dao.Repositories;
using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;

namespace Podemski.Musicorum.Dao
{
    public sealed class DaoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<IAlbum>>().To<AlbumRepository>();
            Bind<IRepository<IArtist>>().To<ArtistRepository>();
            Bind<IRepository<ITrack>>().To<TrackRepository>();

#warning Trzeba wyciągnąć z pliku konfiguracyjnego
            Bind<IDataContext>().To<MemoryContext>();
        }
    }
}
