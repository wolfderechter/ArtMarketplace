using Bogus;
using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Services.Artists;
using EuropArt.Shared.Artists;
using EuropArt.Shared.Artworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuropArt.Shared.Common;

namespace EuropArt.Services.Artworks
{
    public class FakeArtworkService : IArtworkService
    {
        private static List<Artwork> artworks => FakeDataStore.Artworks;
        private static List<Artist> artists => FakeDataStore.Artists;


        //public async Task<ArtworkDto.Detail> GetDetailAsync(int id)
        //{
        //    await Task.Delay(100);
        //    return artworks.SingleOrDefault(x => x.Id == id);
        //}
        public async Task<ArtworkResponse.GetDetail> GetDetailAsync(ArtworkRequest.GetDetail request)
        {
            await Task.Delay(100);

            ArtworkResponse.GetDetail response = new();

            response.Artwork = artworks.Select(x => new ArtworkDto.Detail
            {
                Id = x.Id,
                Name = x.Name,
                ArtistId = x.Artist.Id,
                ArtistName = x.Artist.Name,
                Description = x.Description,
                Price = x.Price,
                ImagePath = x.ImagePath,
            }).SingleOrDefault(x => x.Id == request.ArtworkId);

            return response;
        }

        //public async Task<IEnumerable<ArtworkDto.Index>> GetIndexAsync()
        //{
        //    await Task.Delay(100);
        //    return artworks.AsEnumerable();
        //}
        public async Task<ArtworkResponse.GetIndex> GetIndexAsync(ArtworkRequest.GetIndex request)
        {
            await Task.Delay(100);
            ArtworkResponse.GetIndex response = new();

            //Query om te filteren
            var query = artworks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Searchterm))
                query = query.Where(x => x.Name.Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase) ||
                            x.Artist.Name.Contains(request.Searchterm, StringComparison.OrdinalIgnoreCase));

            if (request.MinimumPrice is not null)
                query = query.Where(x => x.Price >= request.MinimumPrice);

            if (request.MaximumPrice is not null)
                query = query.Where(x => x.Price <= request.MaximumPrice);

            if(request.Style is not null)
            {
                query = query.Where(x => x.Style.Equals(request.Style, StringComparison.OrdinalIgnoreCase));
            }
            if(request.Category is not null)
            {
                query = query.Where(x => x.Category.Equals(request.Category, StringComparison.OrdinalIgnoreCase));
            }

            //auctions includen TODO
            //orderby TODO
            if (request.OrderBy is not null)
            {
                switch (request.OrderBy.Value)
                {
                    case OrderByArtwork.OrderByPriceAscending:
                        query.OrderBy(x => x.Price);
                        break;
                    
                    case OrderByArtwork.OrderByPriceDescending:
                        query.OrderByDescending(x => x.Price);
                        break;
                        
                    case OrderByArtwork.OrderByName:
                        query.OrderBy(x => x.Name);
                        break;

                    //case OrderBy.OrderByOldest:
                    //    query.OrderBy(x => x.);
                    //    break;
                    
                    //case OrderBy.OrderByNewest:
                    //     query.OrderBy(x => x.);
                    //    break;
                    default:
                        break;
                }
            }

            response.Artworks = query.Select(x => new ArtworkDto.Index
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                Price = x.Price,
                ArtistId = x.Artist.Id,
                ArtistName = x.Artist.Name
            }).ToList();

            return response;
        }

        //Temporary for faker
        public List<Artwork> GetArtworks()
        {
            return artworks;
        }

        //public async Task CreateAsync(ArtworkDto.Create model)
        //{
        //    await Task.Delay(100);
        //    //var a = new Artwork(model.Name, model.Price, model.Description);
        //    //api call doen

        //    //MOCK
        //    var artistFaker = new FakeArtistService();
        //    var artists = artistFaker.GetArtists();

        //    var mappedArtwork = new ArtworkDto.Detail
        //    {
        //        Id = artworks.Max(x => x.Id) + 1, //fake id
        //        Name = model.Name,
        //        Price = model.Price,
        //        Description = model.Description,
        //        //MOCK
        //        ImagePath = "/images/NewArtwork.jpg",
        //        Artist = artists.First()
        //    };

        //    artworks.Add(mappedArtwork);
        //    //return model.Id;
        //}
        public async Task<ArtworkResponse.Create> CreateAsync(ArtworkRequest.Create request)
        {
            await Task.Delay(100);
            ArtworkResponse.Create response = new();

            var model = request.Artwork;
            //var price = new Money(model.Price);
            var artwork = new Artwork(model.Name, model.Price, model.Description)
            {
                Id = artworks.Max(x => x.Id) + 1,
                //Fake data opvullen
                Artist = artists.First(),
                ImagePath = model.ImagePath
            };

            artworks.Add(artwork);
            response.ArtworkId = artwork.Id;

            return response;
        }

        public async Task DeleteAsync(ArtworkRequest.Delete request)
        {
            await Task.Delay(100);
            var a = artworks.SingleOrDefault(x => x.Id == request.ArtworkId);
            artworks.Remove(a);
        }

        //Als een artiest wordt verwijderd alle kunstwerken van hem ook verwijderen
        public Task DeleteArtistAsync(int id)
        {
            //var a = artworks.Where(x => x.Artist.Id == id);
            artworks.RemoveAll(a => a.Artist.Id == id);
            return Task.CompletedTask;
        }

        public async Task<ArtworkResponse.Edit> EditAsync(ArtworkRequest.Edit request)
        {
            await Task.Delay(100);

            //artwork exists?
            var artwork = artworks.Single(x => x.Id == request.ArtworkId);

            //artwork aanpassen
            artwork.Name = request.Artwork.Name;
            artwork.Description = request.Artwork.Description;
            artwork.Price = request.Artwork.Price;
            //artwork.ImagePath = request.Artwork.ImagePath;

            //returnen
            ArtworkResponse.Edit response = new();
            response.ArtworkId = artwork.Id;

            return response;
        }

        //Zoeken via search
        public async Task<List<ArtworkDto.Index>> GetIndexAsync(string searchterm)
        {
            await Task.Delay(100);
            return (List<ArtworkDto.Index>)artworks.AsEnumerable().Where(a =>
                a.Description.ToLower().Contains(searchterm) ||
                a.Name.ToLower().Contains(searchterm)
                );
        }
    }
}
