using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Experience
    {
            public int ExpId { get; set; }
            public string UserId { get; set; } //FK UserId
            public string Title { get; set; }
            public string CompanyName { get; set; }
            public string Location { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Description { get; set; }
            public string MediaPhotos { get; set; }
            public string MediaVideos { get; set; }
    }
}
