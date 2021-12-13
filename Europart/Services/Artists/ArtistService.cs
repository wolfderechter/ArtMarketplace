using EuropArt.Domain.Artists;
using EuropArt.Domain.Artworks;
using EuropArt.Persistence.Data;
using EuropArt.Services.Infrastructure;
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
        private readonly IStorageService storageService;
        public ArtistService(HooopDbContext dbContext, IStorageService storageService)
        {
            this.dbContext = dbContext;
            artists = dbContext.Artists;
            artworks = dbContext.Artworks;
            this.storageService = storageService;
        }

        private IQueryable<Artist> GetArtistById(int id) => artists
            .AsNoTracking()
            .Where(p => p.Id == id);

        public async Task DeleteAsync(ArtistRequest.Delete request)
        {
            var artist = artists
                .AsNoTracking()
                .Where(p => p.Id == request.ArtistId).SingleOrDefault();

            storageService.DeleteProfilePictureImage(artist.ImagePath.Remove(0, artist.ImagePath.LastIndexOf('/') + 1));
            artists.RemoveIf(x => x.Id == request.ArtistId);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ArtistResponse.Edit> EditAsync(ArtistRequest.Edit request)
        {
            ArtistResponse.Edit response = new();
            //artist exists?
            var artist = await artists.Where(p => p.Id == request.ArtistId).SingleOrDefaultAsync();

            if (artist is not null)
            {
                var model = request.Artist;
                //only when user wants to change profile picture => request.Artist.ImagePath is not null
                if (request.Artist.ImagePath is not null)
                {
                    var imageExtension = model.ImagePath.Substring(model.ImagePath.LastIndexOf('.'));
                    var imageFileName = Guid.NewGuid().ToString() + imageExtension;
                    var imagePath = $"{storageService.StorageBaseUri}profilepictures/{imageFileName}";

                    //Deleten van oude image in blobstorage, filename doorsturen via DeleteProfilePictureImage 
                    storageService.DeleteProfilePictureImage(artist.ImagePath.Remove(0, artist.ImagePath.LastIndexOf('/') + 1));

                    artist.ImagePath = imagePath;

                    var uploadUri = storageService.CreateUploadUriProfilePictures(imageFileName);
                    response.UploadUri = uploadUri;
                }


                //artist aanpassen
                artist.FirstName = model.FirstName;
                artist.LastName = model.LastName;
                artist.Biography = model.Biography;
                artist.Country = model.Country;
                artist.City = model.City;
                artist.Postalcode = model.Postalcode;
                artist.Street = model.Street;
                artist.Website = model.Website;

                //returnen
                dbContext.Entry(artist).State = EntityState.Modified;

                await dbContext.SaveChangesAsync();
                response.ArtistId = artist.Id;
            }

            return response;
        }

        public async Task<ArtistResponse.GetDetail> GetDetailAsync(ArtistRequest.GetDetail request)
        {
            ArtistResponse.GetDetail response = new();

            response.Artist = await artists.AsNoTracking().Where(p => p.Id == request.ArtistId).Select(x => new ArtistDto.Detail
            {
                Id = x.Id,
                Biography = x.Biography,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Postalcode = x.Postalcode,
                Country = x.Country,
                City = x.City,
                Street = x.Street,
                Website = x.Website,
                ImagePath = x.ImagePath,
                DateCreated = x.DateCreated,
                Artworks = artworks.Where(aw => aw.Artist.Id == x.Id).Select(y => new ArtworkDto.Detail
                {
                    Id = y.Id,
                    Name = y.Name,
                    Description = y.Description,
                    ImagePaths = y.ImagePaths,
                    Price = y.Price,
                }).ToList(),
            }).SingleOrDefaultAsync();

            return response;
        }

        public async Task<ArtistResponse.GetIndex> GetIndexAsync(ArtistRequest.GetIndex request)
        {
            await Task.Delay(100);
            ArtistResponse.GetIndex response = new();

            //Query om te filteren
            var query = artists.AsQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Searchterm))
                query = query.Where(x => (x.FirstName + " " + x.LastName).Contains(request.Searchterm));

            if (request.OrderBy is not null)
            {
                switch (request.OrderBy.Value)
                {
                    case OrderByArtist.OrderByName:
                        query = query.OrderBy(x => x.FirstName + " " + x.LastName);
                        break;
                    case OrderByArtist.OrderByNewest:
                        query = query.OrderByDescending(x => x.DateCreated);
                        break;

                    case OrderByArtist.OrderByOldest:
                        query = query.OrderBy(x => x.DateCreated);
                        break;

                    default:
                        break;
                }
            }
            //wanneer request komt van buiten artist page -> snel resultaten terugeven
            //orderby niet opgevuld dus niet in artist index page
            else
            {
                response.Artists = query.Select(x => new ArtistDto.Index
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Postalcode = x.Postalcode,
                    ImagePath = x.ImagePath,
                    AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count(),
                    DateCreated = x.DateCreated
                }).ToList();

                return response;
            }
            response.TotalAmount = query.Count();
            query = query.Take(request.Amount);
            query = query.Skip(request.Amount * request.Page);

            response.Artists = query.Select(x => new ArtistDto.Index
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Postalcode = x.Postalcode,
                ImagePath = x.ImagePath,
                AmountOfArtworks = artworks.Where(aw => aw.Artist.Id == x.Id).Count(),
                DateCreated = x.DateCreated
            }).ToList();

            return response;
        }

        public async Task<ArtistResponse.Create> CreateAsync(ArtistRequest.Create request)
        {
            await Task.Delay(100);
            ArtistResponse.Create response = new();

            var model = request.Artist;
            var imageExtension = model.ImagePath.Substring(model.ImagePath.LastIndexOf('.'));
            var imageFileName = Guid.NewGuid().ToString() + request.Artist.ImagePath + imageExtension;
            var imagePath = $"{storageService.StorageBaseUri}profilepictures/{imageFileName}";

            var artist = artists.Add(new Artist(model.FirstName, model.LastName, model.Country, model.City, model.PostalCode, model.Street, model.ImagePath, DateTime.Now, model.Biography, model.Website, ""));

            await dbContext.SaveChangesAsync();
            response.ArtistId = artist.Entity.Id;

            return response;
        }
    }
}
