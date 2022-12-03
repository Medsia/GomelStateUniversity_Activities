using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class SportTypeRepository : ISportTypeRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task CreateSportTypeAsync(SportType sportType)
        {
            db.SportTypes.Add(sportType);
            await db.SaveChangesAsync();
        }

        public async Task DeleteSportTypeAsync(int id)
        {
            var SportTypeToDelete = db.SportTypes.FirstOrDefault(x => x.Id == id);
            db.SportTypes.Remove(SportTypeToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<SportType> GetSportTypeAsync(int id)
        {
            return await db.SportTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<SportType>> GetSportTypesAsync()
        {
            return await db.SportTypes.ToListAsync();
        }
    }
}
