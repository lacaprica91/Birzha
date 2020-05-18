using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int PostUserId { get; set; } // FK - user table
        public int PostTypeId { get; set; } //FK - post type table
        public string PostDescription { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
