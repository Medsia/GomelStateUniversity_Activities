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
    public class PsychologistsScheduleModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        private readonly IScheduleRepository _scheduleRepository;

        public PsychologistsScheduleModel(
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IScheduleRepository scheduleRepository)
        {
            _userManager = userManager;
            _logger = logger;
            _scheduleRepository = scheduleRepository;
        }

        public string ReturnUrl { get; set; }


        public IEnumerable<ScheduleItem> scheduleItems { get; set; } = Enumerable.Empty<ScheduleItem>();


        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            scheduleItems = await _scheduleRepository.GetItemsBySubdivIdAsync(6);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            scheduleItems = await _scheduleRepository.GetItemsBySubdivIdAsync(6);
            return Page();
        }
    }
}
