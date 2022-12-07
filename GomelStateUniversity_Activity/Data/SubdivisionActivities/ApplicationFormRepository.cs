using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static GomelStateUniversity_Activity.Data.SubdivisionRepository;

namespace GomelStateUniversity_Activity.Data
{
    public class ApplicationFormRepository : IApplicationFormRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public enum Activity
        {
            Organizer = 1,
            Participant,
            Sport,
            Organizations,
            Labor
        }
        public async Task CreateApplicationFormAsync(IFormCollection form, int subdivId, int activityId, string applicationUserId)
        {
            var activityTypeName = form["ActivityType"].ToString();
            ApplicationForm applicationForm = new ApplicationForm();
            if (subdivId == (int)SubdivisionName.Culture)
            {
                if(activityId == (int)Activity.Organizer)
                    applicationForm = new ApplicationForm(form,
                        db.subdivisionActivityTypes.FirstOrDefault(x => x.Id == activityId),
                        applicationUserId, subdivId, activityId);
                else if(activityId == (int)Activity.Participant)
                    applicationForm = new ApplicationForm(form,
                        db.CreativityTypes.FirstOrDefault(x => x.Name == activityTypeName),
                        applicationUserId, subdivId, activityId);
            }
                
            else if (subdivId == (int)SubdivisionName.Sport)
                applicationForm = new ApplicationForm(form,
                    db.SportTypes.FirstOrDefault(x => x.Name == activityTypeName),
                    applicationUserId, subdivId, activityId);
            else if (subdivId == (int)SubdivisionName.Labor)
            {
                if (activityId == (int)Activity.Organizations)
                    applicationForm = new ApplicationForm(form,
                        Data.Organization.organizationsData.FirstOrDefault(x => x.Name == activityTypeName),
                        applicationUserId, subdivId, activityId);
                else if(activityId == (int)Activity.Labor)
                    applicationForm = new ApplicationForm(form,
                        db.LaborDirections.FirstOrDefault(x => x.Name == activityTypeName),
                        applicationUserId, subdivId, activityId);
            }
                
            db.ApplicationForms.Add(applicationForm);
            await db.SaveChangesAsync();
        }

        public async Task DeleteApplicationFormAsync(int id)
        {
            var applicationFormToDelete = db.ApplicationForms.FirstOrDefault(x => x.Id == id);
            db.ApplicationForms.Remove(applicationFormToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<ApplicationForm> GetApplicationFormAsync(int id)
        {
            return await db.ApplicationForms
                .Include(x => x.Subdivision)
                .Include(x => x.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ApplicationForm>> GetApplicationFormsAsync()
        {
            return await db.ApplicationForms
                .Include(x => x.Subdivision)
                .Include(x => x.ApplicationUser)
                .Include(x => x.SubdivisionActivityType)
                .ToListAsync();
        }

        public async Task<IEnumerable<ApplicationForm>> GetApplicationFormsByUserIdAsync(string userId)
        {
            return await db.ApplicationForms
                .Where(x => x.ApplicationUserId == userId)
                .Include(x => x.Subdivision)
                .Include(x => x.ApplicationUser)
                .Include(x => x.SubdivisionActivityType)
                .ToListAsync();
        }

        public async Task CancelParticipationAsync(int id, string userId, string reason)
        {
            var applicationFormToUpdate = db.ApplicationForms.FirstOrDefault(x => x.Id == id);
            if(userId == applicationFormToUpdate.ApplicationUserId)
            {
                applicationFormToUpdate.ApplicationParameters.Add("Статус", "Отменен");
                applicationFormToUpdate.ApplicationParameters.Add("Причина", reason);
                db.Entry(applicationFormToUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Доступ запрещен");
            }

        }
    }
}
