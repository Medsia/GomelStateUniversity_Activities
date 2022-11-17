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

        public string ReturnUrl { get; set; }

        public IEnumerable<Models.Review> reviews { get; set; } = Enumerable.Empty<Models.Review>();


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            reviews = await _reviewsRepository.GetReviewsAsync();

            return Page();
        }

        public void OnPost(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }
    }
}
