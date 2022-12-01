using GomelStateUniversity_Activity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class CreativityTypeRepository : ICreativityTypeRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task CreateCreativityTypeAsync(CreativityType creativityType)
        {
            db.CreativityTypes.Add(creativityType);
            await db.SaveChangesAsync();
        }

        public async Task DeleteCreativityTypeAsync(int id)
        {
            var CreativityTypeToDelete = db.CreativityTypes.FirstOrDefault(x => x.Id == id);
            db.CreativityTypes.Remove(CreativityTypeToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<CreativityType> GetCreativityTypeAsync(int id)
        {
            return await db.CreativityTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<CreativityType>> GetCreativityTypesAsync()
        {
            return await db.CreativityTypes.ToListAsync();
        }
    }
}
