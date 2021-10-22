﻿using EuropArt.Shared.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.Artist
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDto.Index>> GetIndexAsync();
        Task<ArtistDto.Detail> GetDetailAsync(int id);

    }
}