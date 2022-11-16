using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface ISubdivisionRepository
    {
        public Task<IEnumerable<Subdivision>> GetSubdivisionsAsync();
        public Task<Subdivision> GetSubdivisionAsync(int id);
        public Task CreateSubdivisionAsync(Subdivision subdivision);
        public Task DeleteSubdivisionAsync(int id);
    }
}
