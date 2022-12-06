using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class ScheduleRepository : IScheduleRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task CreateItemAsync(IFormCollection form, DateTime dateTime)
        {
            ScheduleItem newScheduleItem = new ScheduleItem(dateTime, db.Users.FirstOrDefault(x => x.UserName == form["UserName"].ToString()),
                                                                        db.Subdivisions.FirstOrDefault(x => x.Id == int.Parse(form["SubdivId"])) );
            db.Schedule.Add(newScheduleItem);
            await db.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var itemToDelete = db.Schedule.FirstOrDefault(x => x.Id == id);
            db.Schedule.Remove(itemToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<ScheduleItem> GetItemBySubdivIdAsync(int subdivId)
        {
            return await db.Schedule.Include(z => z.ApplicationUser)
                                    .Include(z => z.Subdivision)
                                    .FirstOrDefaultAsync(x => x.Subdivision.Id == subdivId);
        }

        public async Task<ScheduleItem> GetItemAsync(int id)
        {
            return await db.Schedule.Include(z => z.ApplicationUser)
                                    .Include(z => z.Subdivision)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ScheduleItem>> GetItemsAsync()
        {
            return await db.Schedule.Include(z => z.ApplicationUser)
                                    .Include(z => z.Subdivision)
                                    .ToListAsync();
        }

        public async Task UpdateItemAsync(IFormCollection form, DateTime dateTime)
        {
            var itemToUpdate = db.Schedule.FirstOrDefault( x => x.Id == int.Parse( form["Id"] ) );
            var user = db.Users.FirstOrDefault( x => x.UserName == form["UserName"].ToString() );
            var subdiv = db.Subdivisions.FirstOrDefault( x => x.Id == int.Parse( form["SubdivId"] ) );

            itemToUpdate.UpdateScheduleItem(dateTime, user, subdiv);
            db.Entry(itemToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
