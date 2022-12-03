using GomelStateUniversity_Activity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface ISubdivisionActivityTypeRepository
    {
        public Task<IEnumerable<SubdivisionActivityType>> GetSubdivisionActivityTypesAsync();
        public Task<SubdivisionActivityType> GetSubdivisionActivityTypeAsync(int id);

    }
}
