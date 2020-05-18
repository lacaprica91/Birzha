using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public interface IVolunteeringRepository
    {

        IQueryable<Volunteering> Volunteering { get; }
    }
}
