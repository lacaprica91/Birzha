using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class Education
    {
        public int EduId { get; set; }
        public string UserId { get; set; } //FK User Id
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string DegreeType { get; set; }
        public string StudyField { get; set; }
        public string Description { get; set; }
        public string MediaDoc { get; set; }
    }
}
