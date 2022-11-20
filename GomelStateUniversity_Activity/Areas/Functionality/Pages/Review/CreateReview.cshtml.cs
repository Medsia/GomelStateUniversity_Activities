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

        public IEnumerable<Event> events { get; set; } = Enumerable.Empty<Event>();

        public Event knownEvent { get; set; }


        public class InputModel
        {
            [Required(ErrorMessage = "Не выбрано мероприятие")]
            [Display(Name = "Название мероприятия")]
            public int eventId { get; set; }

            [Required(ErrorMessage = "Отзыв не должен быть пустым")]
            [StringLength(255, ErrorMessage = "Максимальный размер отзыва {1} символов.")]
            [Display(Name = "Текст отзыва")]
            public string reviewText { get; set; }
        }


        public async Task OnGetAsync(int eventId, string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            knownEvent = await _eventRepository.GetEventAsync(eventId);

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            currentUsersFullName = user.FullName;

            events = await _eventRepository.GetEventsAsync();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                Dictionary<string, Microsoft.Extensions.Primitives.StringValues> formData = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                {
                    { "Text", Input.reviewText },
                    { "EventId", Input.eventId.ToString() },
                    { "UserName", User.Identity.Name },
                };

                FormCollection form = new FormCollection(formData);
                
                await _reviewsRepository.CreateReviewAsync(form, currentTime);

                _logger.LogInformation("User created a new review.");
            }

            return LocalRedirect(returnUrl);
        }
    }
}
