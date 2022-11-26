using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using GomelStateUniversity_Activity.Data;
using Microsoft.AspNetCore.Http;

namespace GomelStateUniversity_Activity.Areas.Functionality.Pages.Psychologist
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly IScheduleRepository _scheduleRepository;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            ILogger<IndexModel> logger,
            IScheduleRepository scheduleRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _scheduleRepository = scheduleRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public bool isDateValid { get; set; } = false;
        public IEnumerable<ScheduleItem> daySchedule { get; set; } = Enumerable.Empty<ScheduleItem>();


        [Display(Name = "Выбранная дата")]
        [DataType(DataType.Date)]
        public DateTime PrevDate { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Не выбрана дата")]
            [Display(Name = "Выбор даты")]
            [DataType(DataType.Date)]
            public DateTime NewDate { get; set; }

            [HiddenInput]
            [DataType(DataType.Date)]
            public DateTime PrevDate { get; set; }

            [Display(Name = "Время записи")]
            public int Hour { get; set; }
        }


        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }


        public async void OnPostAsync(bool dateUpdated, bool timeSelected, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (dateUpdated)
                {
                    isDateValid = true;
                    PrevDate = Input.NewDate;

                    var schedule = _scheduleRepository.GetItemsAsync().Result;
                    daySchedule = schedule.Where(d => d.DateTime.Date == Input.NewDate.Date)
                                           .AsEnumerable();
                }

                if (timeSelected)
                {
                    Dictionary<string, Microsoft.Extensions.Primitives.StringValues> formData = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                    {
                        { "UserName", User.Identity.Name },
                    };

                    var selectedDateTime = Input.PrevDate;
                    selectedDateTime = selectedDateTime.AddHours(Input.Hour);

                    FormCollection form = new FormCollection(formData);

                    await _scheduleRepository.CreateItemAsync(form, selectedDateTime);

                    //TODO добавить отправку уведомления на почту
                }
            }
        }
    }
}
