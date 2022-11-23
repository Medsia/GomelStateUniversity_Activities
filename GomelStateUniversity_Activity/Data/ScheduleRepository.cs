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
            ScheduleItem newScheduleItem = new ScheduleItem(dateTime, db.Users.FirstOrDefault(x => x.UserName == form["UserName"].ToString()));
            db.Schedule.Add(newScheduleItem);
            await db.SaveChangesAsync();
        }

        public async Task DeleteItemAsync(int id)
        {
            var itemToDelete = db.Schedule.FirstOrDefault(x => x.Id == id);
            db.Schedule.Remove(itemToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<ScheduleItem> GetItemAsync(int id)
        {
            return await db.Schedule.Include(z => z.ApplicationUser)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ScheduleItem>> GetItemsAsync()
        {
            return await db.Schedule.Include(z => z.ApplicationUser)
                                    .ToListAsync();
        }

        public async Task UpdateItemAsync(IFormCollection form, DateTime dateTime)
        {
            var itemToUpdate = db.Schedule.FirstOrDefault( x => x.Id == int.Parse( form["Id"] ) );
            var user = db.Users.FirstOrDefault( x => x.UserName == form["UserName"].ToString() );

            itemToUpdate.UpdateScheduleItem(dateTime, user);
            db.Entry(itemToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
