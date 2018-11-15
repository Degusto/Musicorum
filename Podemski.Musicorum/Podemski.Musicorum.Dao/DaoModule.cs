using System;
using System.Configuration;
using System.Reflection;

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
            var config = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);

            string contextSource = config.AppSettings.Settings["Context"].Value;
            string contextData = config.AppSettings.Settings["ContextData"].Value;

            switch (contextSource)
            {
                case "DAOMock": return new MemoryContext();
                case "DAOFile": return new FileContext(contextData);
                case "DAOSQL": return new DatabaseContext(contextData);
                default: throw new ArgumentOutOfRangeException($"Unknown database: {contextSource}");
            }
        }
    }
}
