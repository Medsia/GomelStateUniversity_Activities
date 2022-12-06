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

        public string ReturnUrl { get; set; }


        public IEnumerable<Review> reviews { get; set; } = Enumerable.Empty<Review>();


        public async void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            reviews = await _reviewsRepository.GetReviewsAsync();
        }

        public async void OnPost(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            reviews = await _reviewsRepository.GetReviewsAsync();
        }
    }
}
