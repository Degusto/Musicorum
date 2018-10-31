using System;
using System.Linq;
using System.Windows.Controls;

using Ninject;

using Podemski.Musicorum.Interfaces;
using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.UI.Bootstrap;
using Podemski.Musicorum.UI.Extensions;
using Podemski.Musicorum.UI.ViewModels;
using Podemski.Musicorum.UI.Views;

namespace Podemski.Musicorum.UI.Factories
{
    internal static class RecordPageFactory
    {
        internal static Page Create(IEntity entity)
        {
            var type = entity.GetType();

            if (Implements(type, typeof(IArtist)))
            {
                return CreatePage<ArtistPage, ArtistViewModel>(entity);
            }
            else if (Implements(type, typeof(IAlbum)))
            {
                return CreatePage<AlbumPage, AlbumViewModel>(entity);
            }
            if (Implements(type, typeof(ITrack)))
            {
                return CreatePage<TrackPage, TrackViewModel>(entity);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(entity));
            }
        }

        private static bool Implements(Type type, Type type2) => type.GetInterfaces().Any(i => i == type2);

        private static Page CreatePage<TPage, TViewModel>(IEntity entity)
            where TPage : Page
            where TViewModel : IRecordViewModel
        {
            var page = Kernel.Instance.Get<TPage>();

            page.GetDataContext<TViewModel>().Initialize(entity.Id);

            return page;
        }
    }
}
