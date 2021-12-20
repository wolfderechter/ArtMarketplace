using EuropArt.Domain.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Common
{
    public class Message
    {
        public int Id { get; set; }
        public Artist Artist { get; set; }
        public YouthArtist YouthArtist { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }


        public Message()
        {

        }

        public Message(Artist artist, YouthArtist youthArtist, DateTime dateCreated, string content, string senderId, string receiverId)
        {
            Artist = artist;
            YouthArtist = youthArtist;
            DateCreated = dateCreated;
            Content = content;
            SenderId = senderId;
            ReceiverId = receiverId;
        }
    }
}