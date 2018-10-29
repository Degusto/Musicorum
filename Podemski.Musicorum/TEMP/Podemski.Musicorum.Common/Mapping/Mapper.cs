using System;

namespace Podemski.Musicorum.Common.Mapping
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }

    internal sealed class Mapper : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource source) => throw new NotImplementedException();
    }
}
