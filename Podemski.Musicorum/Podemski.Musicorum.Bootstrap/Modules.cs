using Ninject.Modules;

using Podemski.Musicorum.BusinessLogic;
using Podemski.Musicorum.Dao;

namespace Podemski.Musicorum.Bootstrap
{
    public static class Modules
    {
        public static INinjectModule[] GetModules() => new INinjectModule[] { new DaoModule(), new BusinessLogicModule() };
    }
}
