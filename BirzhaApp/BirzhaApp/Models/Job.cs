using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public int CompanyId { get; set; } //FK for agency who posted job
        public int JobTypeId { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public string JobDescription { get; set; }
        public string JobIndustry { get; set; }
    }
}
