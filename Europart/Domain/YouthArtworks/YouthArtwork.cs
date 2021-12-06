using Ardalis.GuardClauses;
using EuropArt.Domain.Artists;
using System;

namespace EuropArt.Domain.YouthArtworks
{
    public class YouthArtwork
    {
        public string name;
        public int Id { get; set; }
        public string Name
        {
            get { return name; }
            set { name = Guard.Against.NullOrWhiteSpace(value, nameof(name)); }
        }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateCreated { get; set; }
        public YouthArtist YouthArtist { get; set; }

        public YouthArtwork()
        {

        }

        public YouthArtwork(string name, string description, YouthArtist ya, DateTime dateCreated)
        {
            Name = name;
            Description = description;
            DateCreated = dateCreated;
            YouthArtist = ya;
        }
    }
}
