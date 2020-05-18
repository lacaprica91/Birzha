using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Share
    {
        public int ShareId { get; set; }
        public int SourceId { get; set; } //FK for posts, articles, statuses etc.
        public int ShareTypeId { get; set; } //FK ShareType
        public string ShareName { get; set; }
        public string ShareDescription { get; set; }
    }
}
