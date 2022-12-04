using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public async Task CreateApplicationFormAsync(IFormCollection form, int subdivId, int activityId, string applicationUserId)
        {
            var ActivityTypeName = form["ActivityType"].ToString();
            ApplicationForm applicationForm = new ApplicationForm();
            if (subdivId == 1)
            {
                if(activityId == 1)
                    applicationForm = new ApplicationForm(form,
                        db.subdivisionActivityTypes.FirstOrDefault(x => x.Id == activityId),
                        applicationUserId, subdivId, activityId);
                else if(activityId == 2)
                    applicationForm = new ApplicationForm(form,
                        db.CreativityTypes.FirstOrDefault(x => x.Name == ActivityTypeName),
                        applicationUserId, subdivId, activityId);
            }
                
            else if (subdivId == 2)
                applicationForm = new ApplicationForm(form,
                    db.SportTypes.FirstOrDefault(x => x.Name == ActivityTypeName),
                    applicationUserId, subdivId, activityId);
            else if (subdivId == 4)
            {
                if (activityId == 4)
                    applicationForm = new ApplicationForm(form,
                        Data.Organization.organizationsData.FirstOrDefault(x => x.Name == ActivityTypeName),
                        applicationUserId, subdivId, activityId);
                else if(activityId == 5)
                    applicationForm = new ApplicationForm(form,
                        db.LaborDirections.FirstOrDefault(x => x.Name == ActivityTypeName),
                        applicationUserId, subdivId, activityId);
            }
                
            db.ApplicationForms.Add(applicationForm);
            await db.SaveChangesAsync();
        }

        public async Task DeleteApplicationFormAsync(int id)
        {
            var ApplicationFormToDelete = db.ApplicationForms.FirstOrDefault(x => x.Id == id);
            db.ApplicationForms.Remove(ApplicationFormToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<ApplicationForm> GetApplicationFormAsync(int id)
        {
            return await db.ApplicationForms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ApplicationForm>> GetApplicationFormsAsync()
        {
            return await db.ApplicationForms.ToListAsync();
        }
    }
}
