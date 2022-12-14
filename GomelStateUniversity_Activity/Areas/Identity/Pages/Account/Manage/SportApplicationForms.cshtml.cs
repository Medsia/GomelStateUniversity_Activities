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
    public class SportApplicationFormsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        private readonly IApplicationFormRepository _applicationFormRepository;

        public SportApplicationFormsModel(
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IApplicationFormRepository applicationFormRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _applicationFormRepository = applicationFormRepository;
        }


        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }


        public IEnumerable<ApplicationForm> applicationForms { get; set; } = Enumerable.Empty<ApplicationForm>();

        public int ActivityTypeIdSports { get; } = 3;


        public class InputModel
        {
            [Required]
            [HiddenInput]
            public int FormId { get; set; }
        }


        private async Task GetForms()
        {
            applicationForms = await _applicationFormRepository.GetApplicationFormsAsync();
            applicationForms = applicationForms.Where(a => a.SubdivisionActivityTypeId == ActivityTypeIdSports);
        }

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            await GetForms();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (ModelState.IsValid && Input.FormId != 0)
            {
                await _applicationFormRepository.DeleteApplicationFormAsync(Input.FormId);
            }

            await GetForms();
            return Page();
        }
    }
}
