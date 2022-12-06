using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Data
{
    public interface IScheduleRepository
    {
        public Task CreateItemAsync(IFormCollection form, DateTime dateTime);
        public Task DeleteItemAsync(int id);
        public Task<ScheduleItem> GetItemAsync(int id);
        public Task<IEnumerable<ScheduleItem>> GetItemsAsync();
        public Task UpdateItemAsync(IFormCollection form, DateTime dateTime);
        public Task<ScheduleItem> GetItemBySubdivIdAsync(int subdivId);
    }
}
