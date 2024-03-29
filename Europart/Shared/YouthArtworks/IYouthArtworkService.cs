﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Shared.YouthArtworks
{
    public interface IYouthArtworkService
    {
        Task<YouthArtworkResponse.GetIndex> GetIndexAsync(YouthArtworkRequest.GetIndex request);
        //only used by android
        Task<List<YouthArtworkDto.Detail>> GetYouthArtworksAndroidAsync(YouthArtworkRequest.GetIndex request);
        Task<YouthArtworkResponse.GetDetail> GetDetailAsync(YouthArtworkRequest.GetDetail request);

    }
}
