using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;

using Ninject.Modules;

using Podemski.Musicorum.Dao.Factories;
using Podemski.Musicorum.Dao.Repositories;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.Factories;
using Podemski.Musicorum.Interfaces.Repositories;

namespace Podemski.Musicorum.Dao
{
    public sealed class DaoModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<IAlbum>>().To<AlbumRepository>();
            Bind<IRepository<IArtist>>().To<ArtistRepository>();
            Bind<IRepository<ITrack>>().To<TrackRepository>();
            Bind<IArtistFactory>().To<ArtistFactory>();
            Bind<IAlbumFactory>().To<AlbumFactory>();
            Bind<ITrackFactory>().To<TrackFactory>();
            Bind<Context>().ToMethod(_ => GetContext()).InSingletonScope();
        }

        private static Context GetContext()
        {
            var context = CreateContext();

            context.LoadContext();

            return context;
        }

        private static Context CreateContext()
        {
            string exeLocation = Assembly.GetEntryAssembly().Location;

            var config = ConfigurationManager.OpenExeConfiguration(exeLocation);

            string contextSource = config.AppSettings.Settings["Context"].Value;
            string contextData = config.AppSettings.Settings["ContextData"].Value;

            if(!Path.IsPathRooted(contextSource))
            {
                contextSource = Path.Combine(Path.GetDirectoryName(exeLocation), contextSource);
            }

            var assembly = Assembly.LoadFile(contextSource);

            var contextType = assembly.GetTypes().Single(t => t.IsSubclassOf(typeof(Context)));

            var context = (Context)Activator.CreateInstance(contextType);

            context.Initialize(contextData);

            return context;
        }
    }
}
