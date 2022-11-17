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

        public async Task CreateReviewAsync(IFormCollection form, DateTime dateTime)
        {
            Review newReview = new Review(form, dateTime, db.Events.FirstOrDefault(x => x.Name == form["EventName"].ToString()),
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

        public async Task<IEnumerable<Review>> GetMyReviewsAsync(string userId)
        {
            return await db.Reviews.Include(c => c.ApplicationUser)
                                    .Where(x => x.ApplicationUser.Id == userId).ToListAsync();
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            return await db.Reviews.Include(c => c.ApplicationUser)
                                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync()
        {
            return await db.Reviews.Include(c => c.ApplicationUser)
                                    .ToListAsync();
        }

        public async Task UpdateReviewAsync(IFormCollection form, DateTime dateTime)
        {
            var reviewToUpdate = db.Reviews.FirstOrDefault(x => x.Id == int.Parse(form["Id"]));
            var singleEvent = db.Events.FirstOrDefault(x => x.Name == form["Event"]);
            var appUser = db.Users.FirstOrDefault(x => x.UserName == form["User"]);

            reviewToUpdate.UpdateReview(form, dateTime, singleEvent, appUser);
            db.Entry(reviewToUpdate).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
