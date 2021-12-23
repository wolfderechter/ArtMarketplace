using EuropArt.Domain.Artists;
using EuropArt.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Messages
{
    public class Conversation
    {
        public int Id { get; set; }
      
        public string UserAuthId { get; set; }
        public string ArtistAuthId { get; set; }
        public List<Message> Messages { get; set; } = new();
        public Conversation()
        {

        }

        /*  public Conversation(string artistAuthId, string userAuthId, string artistFirstName, string artistLastName, int artistId)
          {
              ArtistAuthId = artistAuthId;
              UserAuthId = userAuthId;
              ArtistFirstName = artistFirstName;
              ArtistLastName = artistLastName;
              ArtistId = artistId;
          }*/

        public Conversation(string userAuthId, string artistAuthId)
        {
            ArtistAuthId = artistAuthId;
            UserAuthId = userAuthId;

        }
    }
}
