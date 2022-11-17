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

namespace GomelStateUniversity_Activity.Areas.Functionality.Pages.Review
{
    public class CreateReviewModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IEventRepository _eventRepository;

        public CreateReviewModel(
            UserManager<ApplicationUser> userManager,
            ILogger<IndexModel> logger,
            IReviewsRepository reviewsRepository,
            IEventRepository eventRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _reviewsRepository = reviewsRepository;
            _eventRepository = eventRepository;
        }


        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }


        [Display(Name = "ФИО")]
        public string currentUsersFullName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime currentTime { get; set; } = DateTime.Now;

        public List<string> eventNames { get; set; } = new List<string>();

        public string knownEventName { get; set; }


        public class InputModel
        {
            [Required]
            [DataType(DataType.DateTime)]
            [Display(Name = "Дата/время")]
            public DateTime currentTime { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 1)]
            [Display(Name = "Название мероприятия")]
            public string eventName { get; set; }

            [Required]
            [StringLength(255, ErrorMessage = "Максимальный размер отзыва {1} символов.")]
            [Display(Name = "Текст отзыва")]
            public string reviewText { get; set; }
        }


        private async Task SetValues()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            currentUsersFullName = user.FullName;

            var events = await _eventRepository.GetEventsAsync();
            foreach (var ev in events)
            {
                eventNames.Add(ev.Name);
            }

            
            // тестовый кал
            eventNames.Add("Кал ебаный");
        }


        public async Task OnGetAsync(string eventName, string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            knownEventName = eventName;
            await SetValues();
        }


        public async Task OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                Dictionary<string, Microsoft.Extensions.Primitives.StringValues> formData = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                {
                    { "Text", Input.reviewText },
                    { "EventName", Input.eventName },
                    { "UserName", User.Identity.Name },
                };

                FormCollection form = new FormCollection(formData);
                
                await _reviewsRepository.CreateReviewAsync(form, Input.currentTime);

                _logger.LogInformation("User created a new review.");
            }

            await SetValues();
        }
    }
}
