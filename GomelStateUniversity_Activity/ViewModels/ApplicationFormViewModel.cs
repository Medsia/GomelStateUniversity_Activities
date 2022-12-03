using GomelStateUniversity_Activity.Interfaces;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.ViewModels
{
    public class ApplicationFormViewModel
    {
        public IList<SelectListItem> ActivityTypes = new List<SelectListItem>();
        public string ActivityTypeName { get; set; }
        public int SubdivId { get; set; }
        public int ActivityId { get; set; }

        public ApplicationFormViewModel(IList<SportType> subdivActivityTypes, int subdivId, int activityId)
        {
            foreach (var subdivActivityType in subdivActivityTypes)
            {
                ActivityTypes.Add(new SelectListItem() { Text = subdivActivityType.Name });
            }
            SubdivId = subdivId;
            ActivityId = activityId;
        }
        public ApplicationFormViewModel(IList<CreativityType> subdivActivityTypes, int subdivId, int activityId)
        {
            foreach (var subdivActivityType in subdivActivityTypes)
            {
                ActivityTypes.Add(new SelectListItem() { Text = subdivActivityType.Name });
            }
            SubdivId = subdivId;
            ActivityId = activityId;
        }
        public ApplicationFormViewModel(IList<LaborDirection> subdivActivityTypes, int subdivId, int activityId)
        {
            foreach (var subdivActivityType in subdivActivityTypes)
            {
                ActivityTypes.Add(new SelectListItem() { Text = subdivActivityType.Name });
            }
            SubdivId = subdivId;
            ActivityId = activityId;
        }
        public ApplicationFormViewModel(IList<Data.Data.Organization> subdivActivityTypes, int subdivId, int activityId)
        {
            foreach (var subdivActivityType in subdivActivityTypes)
            {
                ActivityTypes.Add(new SelectListItem() { Text = subdivActivityType.Name });
            }
            SubdivId = subdivId;
            ActivityId = activityId;
        }
        public ApplicationFormViewModel(string activityTypeName, int subdivId, int activityId)
        {
            ActivityTypeName = activityTypeName;
            SubdivId = subdivId;
            ActivityId = activityId;
        }
        public ApplicationFormViewModel()
        {

        }
    }
}
