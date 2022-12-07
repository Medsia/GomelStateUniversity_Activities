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

namespace GomelStateUniversity_Activity.Areas.Functionality.Pages.Review
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<IndexModel> _logger;
        private readonly IReviewsRepository _reviewsRepository;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            ILogger<IndexModel> logger,
            IReviewsRepository reviewsRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _reviewsRepository = reviewsRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }


        public string ReturnUrl { get; set; }

        public IEnumerable<Models.Review> reviews { get; set; } = Enumerable.Empty<Models.Review>();

        public class InputModel
        {
            [Required]
            [HiddenInput]
            public int ReviewId { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            reviews = await _reviewsRepository.GetReviewsAsync(true);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(bool isOnReview, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (isOnReview)
                {
                    var selectedReview = await _reviewsRepository.GetReviewAsync(Input.ReviewId);
                    await _reviewsRepository.UpdateReviewAsync(selectedReview, false);
                }
            }

            reviews = await _reviewsRepository.GetReviewsAsync(true);
            return Page();
        }
    }
}
