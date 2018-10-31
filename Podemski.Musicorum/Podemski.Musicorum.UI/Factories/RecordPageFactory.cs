﻿using System;
using System.Linq;
using System.Windows.Controls;

using Ninject;

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
                var page = CreatePage<ArtistPage>();
                page.GetDataContext<ArtistViewModel>().Initialize((IArtist)entity);
                return page;
            }
            else if (Implements(type, typeof(IAlbum)))
            {
                var page = CreatePage<AlbumPage>();
                page.GetDataContext<AlbumViewModel>().Initialize((IAlbum)entity);
                return page;
            }
            if (Implements(type, typeof(ITrack)))
            {
                var page = CreatePage<TrackPage>();
                page.GetDataContext<TrackViewModel>().Initialize((ITrack)entity);
                return page;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(entity));
            }
        }

        private static bool Implements(Type type, Type type2) => type.GetInterfaces().Any(i => i == type2);

        private static Page CreatePage<TPage>()
            where TPage : Page
        {
            return Kernel.Instance.Get<TPage>();
        }
    }
}
