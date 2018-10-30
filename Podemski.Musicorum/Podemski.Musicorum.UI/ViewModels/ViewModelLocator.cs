using System;
using System.Linq;

using Ninject;
using Ninject.Modules;

namespace Podemski.Musicorum.UI.ViewModels
{
    public sealed class ViewModelLocator
    {
        private readonly IKernel _kernel;

        public ViewModelLocator()
        {
            var settings = new NinjectSettings
            {
                InjectNonPublic = true
            };

            var modules = GetModules();

            _kernel = new StandardKernel(settings, modules);
        }

        public MainViewModel MainViewModel => _kernel.Get<MainViewModel>();

        public ArtistViewModel ArtistViewModel => _kernel.Get<ArtistViewModel>();

        public AlbumViewModel AlbumViewModel => _kernel.Get<AlbumViewModel>();

        public TrackViewModel TrackViewModel => _kernel.Get<TrackViewModel>();

        private static INinjectModule[] GetModules()
        {
            return AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType == typeof(NinjectModule) && t.IsSealed)
                .Select(m => (INinjectModule)Activator.CreateInstance(m)).ToArray();
        }
    }
}