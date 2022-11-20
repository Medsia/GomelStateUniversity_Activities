using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IReviewsRepository
    {
        public Task<IEnumerable<Models.Review>> GetReviewsAsync();
        public Task<IEnumerable<Models.Review>> GetMyReviewsAsync(string userId);
        public Task<Models.Review> GetReviewAsync(int id);
        public Task CreateReviewAsync(IFormCollection form);
        public Task UpdateReviewAsync(IFormCollection form);
        public Task DeleteReviewAsync(int id);
    }
}
