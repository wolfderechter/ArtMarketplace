using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Persistence.Data;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using EuropArt.Shared.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Services.Artists
{
   public class ArtistService : IArtistService
    {
        private readonly HooopDbContext dbContext;
        private readonly DbSet<Artist> artists;
        private readonly DbSet<Artwork> artworks;
        
        public ArtistService(HooopDbContext dbContext)
        {
            this.dbContext = dbContext;
            artists = dbContext.Artists;
            artworks = dbContext.Artworks;
        }

        private IQueryable<Artist> GetArtistById(int id) => artists
            .AsNoTracking()
            .Where(p => p.Id == id);

        public async Task DeleteAsync(ArtistRequest.Delete request)
        {
            await Task.Delay(100);
            var a = artists.SingleOrDefault(x => x.Id == request.ArtistId);
            artists.Remove(a);
        }

        public async Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request)
        {
            await Task.Delay(100);

            //artist exists?
            var artist = artists.Single(x => x.Id == request.ArtistId);

            //artist aanpassen
            artist.Name = request.Artist.Name;
            artist.Biography = request.Artist.Biography;
            artist.Address = request.Artist.Address;
            artist.Website = request.Artist.Website;

            //returnen
            ArtistResponse.Edit response = new();
            response.ArtistId = artist.Id;
            return response;
        }

        public async Task<ArtistResponse.GetDetail> GetDetailAsync(ArtistRequest.GetDetail request)
        {
            await Task.Delay(100);
            ArtistResponse.GetDetail response = new();

            response.Artist = artists.AsNoTracking().Include(p => p.Artworks).Where(p => p.Id == request.ArtistId).Select(x => new YouthArtistDto.Detail
            {
                Id = x.Id,
                Biography = x.Biography,
                Address = x.Address,
                Name = x.Name,
                Website = x.Website,
                ImagePath = x.ImagePath,
                DateCreated = x.DateCreated,
                Artworks = artworks.Where(aw => aw.Artist.Id == x.Id).Select(y => new ArtworkDto.Detail
                {
                    Id = y.Id,
                    Name = y.Name,
                    Description = y.Description,
                    ImagePath = y.ImagePath,
                    Price = y.Price,
                }).ToList(),
            }).SingleOrDefault(x => x.Id == request.ArtistId);

            return response;
        }

        public async Task<ArtistResponse.GetIndex> GetIndexAsync(ArtistRequest.GetIndex request)
        {
            await Task.Delay(100);
            ArtistResponse.GetIndex response = new();

            //Query om te filteren
            var query = artists.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Searchterm))
                query = query.Where(x => x.Name.ToString().Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase));

            var query2 = new List<Artist>();
            if (request.OrderBy is not null)
            {
                switch (request.OrderBy.Value)
                {
                    case OrderByArtist.OrderByName:
                        query2 = query.OrderBy(x => x.Name.ToString()).ToList();
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
            }
            //wanneer request komt van buiten artist page -> snel resultaten terugeven
            //orderby niet opgevuld dus niet in artist index page
            else
            {
                response.Artists = query.Select(x => new YouthArtistDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    ImagePath = x.ImagePath,
                    AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count(),
                    DateCreated = x.DateCreated
                }).ToList();

                return response;
            }
            response.TotalAmount = query2.Count();
            query2 = query2.Skip(request.Amount * request.Page).ToList();
            query2 = query2.Take(request.Amount).ToList();

            response.Artists = query2.Select(x => new YouthArtistDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                ImagePath = x.ImagePath,
                AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count(),
                DateCreated = x.DateCreated
            }).ToList();

            return response;
        }
    }
}
