using EuropArt.Domain.Artists;
using EuropArt.Domain.YouthArtworks;
using EuropArt.Persistence.Data;
using EuropArt.Shared.YouthArtists;
using EuropArt.Shared.YouthArtworks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropArt.Services.Youths
{
    public class YouthArtistService : IYouthArtistService
    {
        private readonly HooopDbContext dbContext;
        private readonly DbSet<YouthArtist> youthArtists;
        private readonly DbSet<YouthArtwork> youthArtworks;


        public YouthArtistService(HooopDbContext dbContext)
        {
            this.dbContext = dbContext;
            youthArtists = dbContext.YouthArtists;
            youthArtworks = dbContext.YouthArtworks;
        }
        public async Task DeleteAsync(YouthArtistRequest.Delete request)
        {
            youthArtists.RemoveIf(x => x.Id == request.YouthArtistId);
            await dbContext.SaveChangesAsync();
        }

        public Task<YouthArtistResponse.Edit> EditAsync(YouthArtistRequest.Edit request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<YouthArtistResponse.GetDetail> GetDetailAsync(YouthArtistRequest.GetDetail request)
        {
            YouthArtistResponse.GetDetail response = new();

            response.Artist = await youthArtists.AsNoTracking().Where(p => p.Id == request.YouthArtistId).Select(x => new YouthArtistDto.Detail
            {
                Id = x.Id,
                //Country = x.Country;
                //City = x.City;
                //Postalcode = x.Postalcode;
                //Street = x.Street;
                FirstName = x.FirstName,
                LastName = x.LastName,
                ImagePath = x.ImagePath,
                DateCreated = x.DateCreated,
                Artworks = youthArtworks.Where(aw => aw.YouthArtist.Id == x.Id).Select(y => new YouthArtworkDto.Detail
                {
                    Id = y.Id,
                    Name = y.Name,
                    Description = y.Description,
                    ImagePath = y.ImagePath,
                }).ToList(),
            }).SingleOrDefaultAsync();

            return response;
        }

        public async Task<YouthArtistResponse.GetIndex> GetIndexAsync(YouthArtistRequest.GetIndex request)
        {
            await Task.Delay(100);
            YouthArtistResponse.GetIndex response = new();

            //Query om te filteren
            var query = youthArtists.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Searchterm))
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase));

            var query2 = new List<YouthArtist>(); 
            /*if (request.OrderBy is not null)
            {
                switch (request.OrderBy.Value)
                {
                    case OrderByArtist.OrderByName:
                        query2 = query.ToList();
                        //query2 = query.OrderBy(x => x.Name.ToString()).ToList();
                        break;
                    //case OrderByArtist.OrderByNewest:
                    //    query.OrderByDescending(x => x.);
                    //    break;

                    //case OrderByArtist.OrderByOldest:
                    //    query.OrderBy(x => x.);
                    //    break;

                    default:
                        query2 = query.ToList();
                        break;
                }
            }*/
            //wanneer request komt van buiten artist page -> snel resultaten terugeven
            //orderby niet opgevuld dus niet in artist index page
         /*   else
            {*/
                response.YouthArtists = query.Select(x => new YouthArtistDto.Index
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    //City = x.city, ..... nog uitwerken
                    ImagePath = x.ImagePath,
                    AmountOfArtworks = youthArtworks.Where(aw => aw.YouthArtist.Id == x.Id).Count(),
                    DateCreated = x.DateCreated
                }).ToList();

                return response;
         /*   }*/
            response.TotalAmount = query2.Count();
            query2 = query2.Skip(request.Amount * request.Page).ToList();
            query2 = query2.Take(request.Amount).ToList();

            response.YouthArtists = query2.Select(x => new YouthArtistDto.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                //Address = x.Address,
                ImagePath = x.ImagePath,
                AmountOfArtworks = youthArtworks.Where(aw => aw.YouthArtist.Id == x.Id).Count(),
                DateCreated = x.DateCreated
            }).ToList();

            return response;
        }
    }
}

