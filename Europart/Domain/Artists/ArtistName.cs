using Ardalis.GuardClauses;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Artists
{
    public class ArtistName : ValueObject
    {
        public string FirstName { get; set;  }
        public string LastName { get; set;  }

        public ArtistName()
        {

        }

        public ArtistName(string firstname, string lastname)
        {
            FirstName = Guard.Against.NullOrEmpty(firstname, nameof(firstname));
            LastName = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName.ToLower();
            yield return LastName.ToLower();
        }
    }
}
