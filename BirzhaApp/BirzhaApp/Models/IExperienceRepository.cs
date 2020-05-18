using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public interface IExperienceRepository
    {
        IQueryable<Experience> Experience { get; }
    }
}
