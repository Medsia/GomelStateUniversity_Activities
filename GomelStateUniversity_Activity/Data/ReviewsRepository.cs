using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public class ReviewsRepository : IReviewsRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task CreateReviewAsync(IFormCollection form)
        {
            Review newReview = new Review(form, DateTime.Now, db.Events.FirstOrDefault(x => x.Id == int.Parse(form["EventId"])),
                                                            db.Users.FirstOrDefault(x => x.UserName == form["UserName"].ToString()));
            db.Reviews.Add(newReview);
            await db.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int id)
        {
            var reviewToDelete = db.Reviews.FirstOrDefault(x => x.Id == id);
            db.Reviews.Remove(reviewToDelete);
            await db.SaveChangesAsync();
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            return await db.Reviews.Include(z => z.Event)
                                    .Include(c => c.ApplicationUser)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await db.Reviews.Include(z => z.Event)
                                    .Include(c => c.ApplicationUser)
                                    .OrderByDescending(d => d).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(bool isAccepted)
        {
            return await db.Reviews.Include(z => z.Event)
                                    .Include(c => c.ApplicationUser)
                                    .Where(r => r.IsAccepted == isAccepted)
                                    .OrderByDescending(d => d).ToListAsync();
        }

        public async Task UpdateReviewAsync(IFormCollection form, bool isAccepted)
        {
            var reviewToUpdate = db.Reviews.FirstOrDefault(x => x.Id == int.Parse(form["Id"]));
            var singleEvent = db.Events.FirstOrDefault(x => x.Name == form["Event"].ToString());
            var appUser = db.Users.FirstOrDefault(x => x.UserName == form["User"].ToString());

            reviewToUpdate.UpdateReview(form, DateTime.Now, singleEvent, appUser, isAccepted);
            db.Entry(reviewToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(Review reviewToUpdate, bool isAccepted)
        {
            var text = reviewToUpdate.Text;
            var date = reviewToUpdate.DateTime;
            var singleEvent = reviewToUpdate.Event;
            var appUser = reviewToUpdate.ApplicationUser;

            reviewToUpdate.UpdateReview(text, date, singleEvent, appUser, isAccepted);
            db.Entry(reviewToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
