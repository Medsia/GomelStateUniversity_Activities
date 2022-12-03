using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class SubdivisionRepository : ISubdivisionRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task UpdateSubdivisionAsync(Subdivision subdivision)
        {
            db.Subdivisions.Update(subdivision);
            await db.SaveChangesAsync();
        }

        public async Task<Subdivision> GetSubdivisionAsync(int id)
        {
            return await db.Subdivisions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Subdivision>> GetSubdivisionsAsync()
        {
            return await db.Subdivisions.ToListAsync();
        }
    }
}
