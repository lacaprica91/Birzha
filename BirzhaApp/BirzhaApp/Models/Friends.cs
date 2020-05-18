using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Friends
    {
        public int UserId { get; set; } // FK user table
        public int FriendId { get; set; } // FK user table
    }
}
