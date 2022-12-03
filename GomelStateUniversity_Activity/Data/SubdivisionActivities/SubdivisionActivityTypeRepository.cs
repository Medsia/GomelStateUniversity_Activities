using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class SubdivisionActivityTypeRepository : ISubdivisionActivityTypeRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<SubdivisionActivityType> GetSubdivisionActivityTypeAsync(int id)
        {
            return await db.subdivisionActivityTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SubdivisionActivityType>> GetSubdivisionActivityTypesAsync()
        {
            return await db.subdivisionActivityTypes.ToListAsync();
        }
    }
}
