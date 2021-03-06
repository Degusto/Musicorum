﻿using System.Collections.Generic;

using Podemski.Musicorum.Interfaces.Entities;
using Podemski.Musicorum.Interfaces.SearchCriterias;

namespace Podemski.Musicorum.Interfaces.Services
{
    public interface ITrackService
    {
        void Save(ITrack track);

        void Delete(ITrack track);

        ITrack Get(int trackId);

        IEnumerable<ITrack> Find(SearchCriteria searchCriteria);
    }
}
