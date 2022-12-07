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
using UnidecodeSharpFork;
using GomelStateUniversity_Activity.Data;
using Microsoft.AspNetCore.Http;

namespace GomelStateUniversity_Activity.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "admin, supervisor")]
    public class ModReviewsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        private readonly IReviewsRepository _reviewsRepository;

        public ModReviewsModel(
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IReviewsRepository reviewsRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _reviewsRepository = reviewsRepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }


        public IEnumerable<Review> reviews { get; set; } = Enumerable.Empty<Review>();


        public class InputModel
        {
            [Required]
            [HiddenInput]
            public int ReviewId { get; set; }
        }


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            reviews = await _reviewsRepository.GetReviewsAsync(false);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(bool isAccepted, string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                if (isAccepted)
                {
                    var selectedReview = await _reviewsRepository.GetReviewAsync(Input.ReviewId);
                    await _reviewsRepository.UpdateReviewAsync(selectedReview, true);
                }
                else
                {
                    await _reviewsRepository.DeleteReviewAsync(Input.ReviewId);
                }
                
            }

            reviews = _reviewsRepository.GetReviewsAsync(false).Result;
            return Page();
        }
    }
}
