using GomelStateUniversity_Activity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface ILaborDirectionRepository
    {
        public Task<IEnumerable<LaborDirection>> GetLaborDirectionsAsync();
        public Task<LaborDirection> GetLaborDirectionAsync(int id);
        public Task CreateLaborDirectionAsync(LaborDirection laborDirection);
        public Task DeleteLaborDirectionAsync(int id);
    }
}
