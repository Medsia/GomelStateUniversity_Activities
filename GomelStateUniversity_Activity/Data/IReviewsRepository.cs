using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IReviewsRepository
    {
        public Task<IEnumerable<Models.Review>> GetReviewsAsync();
        public Task<IEnumerable<Models.Review>> GetReviewsAsync(bool isAccepted);
        public Task<Models.Review> GetReviewAsync(int id);
        public Task CreateReviewAsync(IFormCollection form);
        public Task UpdateReviewAsync(IFormCollection form, bool isAccepted);
        public Task UpdateReviewAsync(Models.Review reviewToUpdate, bool isAccepted);
        public Task DeleteReviewAsync(int id);
    }
}
