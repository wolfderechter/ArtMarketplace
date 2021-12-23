using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Users
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AuthId { get; set; }
        public DateTime DateCreated { get; set; }
        public User()
        {

        }
        public User(string firstName, string lastName, string authId, DateTime dateCreated)
        {
            FirstName = firstName;      
            LastName = lastName;
            AuthId = authId;
            DateCreated = dateCreated;
        }
    }
}
