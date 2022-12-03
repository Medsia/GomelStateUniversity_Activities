using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class LaborDirectionRepository : ILaborDirectionRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task CreateLaborDirectionAsync(LaborDirection laborDirection)
        {
            db.LaborDirections.Add(laborDirection);
            await db.SaveChangesAsync();
        }

        public async Task DeleteLaborDirectionAsync(int id)
        {
            var LaborDirectionToDelete = db.LaborDirections.FirstOrDefault(x => x.Id == id);
            db.LaborDirections.Remove(LaborDirectionToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<LaborDirection> GetLaborDirectionAsync(int id)
        {
            return await db.LaborDirections.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<LaborDirection>> GetLaborDirectionsAsync()
        {
            return await db.LaborDirections.ToListAsync();
        }
    }
}
