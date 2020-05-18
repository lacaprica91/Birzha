using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class CompanyFollowers
    {
        public int CompanyFollowersId { get; set; }
        public int CompanyId { get; set; }
        public int FollowerId { get; set; }
    }
}
