using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirzhaApp.Models
{
    public class EFVolunteeringRepository : IVolunteeringRepository
    {
        private ApplicationDbContext context;

        public EFVolunteeringRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Volunteering> Volunteering => context.Volunteering;
    }
}
