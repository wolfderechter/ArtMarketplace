using Bogus;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using EuropArt.Domain.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuropArt.Services.Artworks;
using EuropArt.Domain.Artworks;
using EuropArt.Shared.Common;

namespace EuropArt.Services.Artists
{
    public class FakeArtistService : IArtistService
    {
        private static List<Artwork> artworks => FakeDataStore.Artworks;
        private static List<Artist> artists => FakeDataStore.Artists;

        public async Task DeleteAsync(ArtistRequest.Delete request)
        {
            await Task.Delay(100);
            var a = artists.SingleOrDefault(x => x.Id == request.ArtistId);
            artists.Remove(a);

            var artworkFaker = new FakeArtworkService();
            await artworkFaker.DeleteArtistAsync(request.ArtistId);
        }

        public async Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request)
        {
            await Task.Delay(100);

            //artist exists?
            var artist = artists.Single(x => x.Id == request.ArtistId);

            //artist aanpassen
            artist.Name = request.Artist.Name;
            artist.Biography = request.Artist.Biography;
            artist.City = request.Artist.City;
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

            response.Artist = artists.Select(x => new ArtistDto.Detail
            {
                Id = x.Id,
                Biography = x.Biography,
                City = x.City,
                Name = x.Name,
                Website = x.Website,
                ImagePath = x.ImagePath,
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
            var query = artists.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Searchterm))
                query = query.Where(x => x.Name.Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase));

            var query2 = new List<Artist>();
            if (request.OrderBy is not null)
            {
                switch (request.OrderBy.Value)
                {
                    case OrderByArtist.OrderByName:
                        query2 = query.OrderBy(x => x.Name).ToList();
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
            else
            {
                response.Artists = query.Select(x => new ArtistDto.Index
                {
                    Id = x.Id,
                    Name = x.Name,
                    City = x.City,
                    ImagePath = x.ImagePath,
                    AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count()
                }).ToList();

                return response;
            }

            response.Artists = query2.Select(x => new ArtistDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                City = x.City,
                ImagePath = x.ImagePath,
                AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count()
            }).ToList();

            return response;
        }

        //nog uitwerken
        public Task<List<ArtistDto.Index>> GetIndexAsync(string searchterm)
        {
            throw new NotImplementedException();
        }

        public List<Artist> GetArtists()
        {
            return artists;
        }

        //public async Task<ArtistDto.Detail> GetDetailAsync(int id)
        //{
        //    await Task.Delay(100);
        //    return artists.SingleOrDefault(x => x.Id == id);
        //}

        //public async Task<IEnumerable<ArtistDto.Index>> GetIndexAsync()
        //{
        //    await Task.Delay(100);
        //    return artists.AsEnumerable();
        //}

        //public IEnumerable<ArtistDto.Detail> GetArtists()
        //{
        //    return artists;
        //}

        //public async Task<IEnumerable<ArtistDto.Index>> GetIndexAsync(string searchterm)
        //{
        //    await Task.Delay(100);
        //    return artists.AsEnumerable().Where(a => a.Name.ToLower().Contains(searchterm) || a.Biography.ToLower().Contains(searchterm));
        //}

        //public Task UpdateArtistAsync(ArtistDto.Edit model, int id)
        //{
        //    var a = artists.SingleOrDefault(x => x.Id == id);

        //    a.Name = model.Name;
        //    a.City = model.City;
        //    a.Website = model.Website;
        //    a.Biography = model.Biography;

        //    return Task.CompletedTask;
        //}

        //public Task DeleteAsync(int id)
        //{
        //    var a = artists.SingleOrDefault(x => x.Id == id);
        //    artists.Remove(a);
        //    return Task.CompletedTask;
        //}
    }
}
