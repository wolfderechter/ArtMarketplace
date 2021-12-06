using Ardalis.GuardClauses;
using Domain;
using System.Collections.Generic;

namespace EuropArt.Domain.Common
{
    public class Address : ValueObject
    {
        public string Country { get; set; }
        public string City { get; set;  }
        public string Postalcode { get; set; }
        public string Street { get; set; }



        public Address(string country, string city, string postalcode, string street)
        {
            Country = country;
            City = city;
            Postalcode = postalcode;
            Street = street;
            /*Country = Guard.Against.NullOrEmpty(country, nameof(country));
            City = Guard.Against.NullOrEmpty(city, nameof(city));
            Postalcode = Guard.Against.NullOrEmpty(postalcode, nameof(postalcode));
            Street = Guard.Against.NullOrEmpty(street, nameof(street));*/
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street.ToLower();
            yield return Country.ToLower();
            yield return Postalcode.ToLower();
            yield return City.ToLower();
        }
    }
}
