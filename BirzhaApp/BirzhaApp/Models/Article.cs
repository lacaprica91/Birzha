using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public int TypeId { get; set; } //FK for ArticleType
        public int AuthorId { get; set; } //FK User Id
        public DateTime DateCreated { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
