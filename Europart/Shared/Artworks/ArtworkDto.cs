using EuropArt.Shared.Artist;
using System.ComponentModel.DataAnnotations;

namespace EuropArt.Shared.Artworks
{
    public static class ArtworkDto
    {
        public class Index
        {
            // [Required]
            public int Id { get; set; }
            public ArtistDto.Detail Artist { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "Name is too long.")]
            public string Name { get; set; }
            [Required]
            [Range(0, 10000000, ErrorMessage = "Price cannot be negative")]
            public decimal Price { get; set; }
            [Required]
            public string ImagePath { get; set; }
        }

        public class Detail : Index
        {
            public string Description { get; set; }
        }

    }
}
