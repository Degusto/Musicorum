using System;
using System.Linq;

using Ninject;
using Ninject.Modules;
using Podemski.Musicorum.Bootstrap;

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

            var modules = Modules.GetModules().ToList();

            modules.Add(new UiModule());

            Instance = new StandardKernel(settings, modules.ToArray());
        }
    }
}
