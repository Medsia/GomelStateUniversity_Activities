using GomelStateUniversity_Activity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface ISportTypeRepository
    {
        public Task<IEnumerable<SportType>> GetSportTypesAsync();
        public Task<SportType> GetSportTypeAsync(int id);
        public Task CreateSportTypeAsync(SportType sportType);
        public Task DeleteSportTypeAsync(int id);
    }
}
