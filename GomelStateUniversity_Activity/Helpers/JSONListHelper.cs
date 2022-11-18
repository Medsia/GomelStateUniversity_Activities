using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Helpers
{
    public static class JSONListHelper
    {
        public static string GetEventListJSONString(IEnumerable<Models.Event> events)
        {
            var calendarEventList = new List<Event>();
            foreach (var model in events)
            {
                var myEVent = new Event()
                {
                    id = model.Id,
                    title = model.Name,
                    description = model.Description,
                    start = model.DateTime,
                    resourceId = model.Subdivision.Id
                };
                calendarEventList.Add(myEVent);
            }
            return System.Text.Json.JsonSerializer.Serialize(calendarEventList);
        }

        public static string GetResourceListJSONString(IEnumerable<Models.Subdivision> subdivisions)
        {
            var calendarResourceList = new List<Resource>();
            foreach (var model in subdivisions)
            {
                var resource = new Resource()
                {
                    id = model.Id,
                    title = model.Name
                };
                calendarResourceList.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(calendarResourceList);
        }
    }

    public class Event
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime start { get; set; }
        public int resourceId { get; set; }
    }

    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
