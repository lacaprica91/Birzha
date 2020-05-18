using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ReceiverId { get; set; } //FK User id
        public int SenderId { get; set; }   //FK User id
        public string MessageBody { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
