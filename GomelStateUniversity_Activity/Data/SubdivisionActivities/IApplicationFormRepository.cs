using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IApplicationFormRepository
    {
        public Task<IEnumerable<ApplicationForm>> GetApplicationFormsAsync();
        public Task<ApplicationForm> GetApplicationFormAsync(int id);
        public Task CreateApplicationFormAsync(IFormCollection form, int subdivId, int activityId);
        public Task DeleteApplicationFormAsync(int id);
    }
}
