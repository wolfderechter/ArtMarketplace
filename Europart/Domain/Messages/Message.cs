using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuropArt.Domain.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string SenderAuthId { get; set; }
        public int ConversationId { get; set; }
        public string Content { get; set; }
        public Message()
        {

        }

        public Message(string content, DateTime dateCreated, string senderAuthId)
        {
            DateCreated = dateCreated;  
            SenderAuthId = senderAuthId;
            Content = content;
        }
    }
}
