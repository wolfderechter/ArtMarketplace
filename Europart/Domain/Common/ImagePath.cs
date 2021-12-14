using System.ComponentModel.DataAnnotations;

namespace EuropArt.Domain.Common
{
    public class ImagePath
    {
        [Key]
        public int ImagePathId { get; set; }
        public string imagePath { get; set; }
        public int ArtworkId { get; set; }

        public ImagePath()
        {

        }

        public ImagePath(string imagePath)
        {
            this.imagePath = imagePath;
        }
    }
}