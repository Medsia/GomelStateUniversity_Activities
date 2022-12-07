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
    public class CreativityApplicationFormsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        private readonly IApplicationFormRepository _applicationFormRepository;

        public CreativityApplicationFormsModel(
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IApplicationFormRepository applicationFormRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _applicationFormRepository = applicationFormRepository;
        }

        public string ReturnUrl { get; set; }


        public IEnumerable<ApplicationForm> applicationForms { get; set; } = Enumerable.Empty<ApplicationForm>();


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            applicationForms = await _applicationFormRepository.GetApplicationFormsAsync();
            applicationForms = applicationForms.Where(a => a.SubdivisionActivityTypeId == 1 || a.SubdivisionActivityTypeId == 2);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            applicationForms = await _applicationFormRepository.GetApplicationFormsAsync();
            applicationForms = applicationForms.Where(a => a.SubdivisionActivityTypeId == 1 || a.SubdivisionActivityTypeId == 2);
            return Page();
        }
    }
}
