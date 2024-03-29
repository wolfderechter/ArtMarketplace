﻿using EuropArt.Domain.YouthArtworks;
using EuropArt.Persistence.Data;
using EuropArt.Services.Artworks;
using EuropArt.Services.Infrastructure;
using EuropArt.Shared.YouthArtworks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EuropArt.Services.Youths
{
    public class YouthArtworkService : IYouthArtworkService
    {
        private readonly HooopDbContext dbContext;
        private readonly DbSet<YouthArtwork> youthArtworks;
        private readonly IStorageService storageService;
        public YouthArtworkService(HooopDbContext dbContext, IStorageService storageService)
        {
            this.dbContext = dbContext;
            youthArtworks = dbContext.YouthArtworks;
            this.storageService = storageService;

        }
        private IQueryable<YouthArtwork> GetArtworkById(int id) => youthArtworks
           .AsNoTracking()
           .Where(p => p.Id == id);

        public async Task<YouthArtworkResponse.GetDetail> GetDetailAsync(YouthArtworkRequest.GetDetail request)
        {
            YouthArtworkResponse.GetDetail response = new();

            response.YouthArtwork = await GetArtworkById(request.YouthArtworkId).Select(x => new YouthArtworkDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
            })
            .SingleOrDefaultAsync(x => x.Id == request.YouthArtworkId);

            return response;
        }

        public async Task<YouthArtworkResponse.GetIndex> GetIndexAsync(YouthArtworkRequest.GetIndex request)
        {
            await Task.Delay(100);
            YouthArtworkResponse.GetIndex response = new();

            response.YouthArtworks = youthArtworks.Select(x => new YouthArtworkDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
            }).ToList();

            return response;
        }
        //only used by android
        public async Task<List<YouthArtworkDto.Detail>> GetYouthArtworksAndroidAsync(YouthArtworkRequest.GetIndex request)
        {
            await Task.Delay(100);

            var response = youthArtworks.Select(x => new YouthArtworkDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
            }).ToList();

            return response;
        }
    }
}
