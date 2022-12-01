using GomelStateUniversity_Activity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface ICreativityTypeRepository
    {
        public Task<IEnumerable<CreativityType>> GetCreativityTypesAsync();
        public Task<CreativityType> GetCreativityTypeAsync(int id);
        public Task CreateCreativityTypeAsync(CreativityType creativityType);
        public Task DeleteCreativityTypeAsync(int id);
    }
}
