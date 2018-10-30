using System;
using System.Linq;

using Ninject;
using Ninject.Modules;

namespace Podemski.Musicorum.UI.Bootstrap
{
    internal static class Kernel
    {
        internal static IKernel Instance { get; }

        static Kernel()
        {
            var settings = new NinjectSettings
            {
                InjectNonPublic = true
            };

            var modules = GetModules();

            Instance = new StandardKernel(settings, modules);
        }

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
