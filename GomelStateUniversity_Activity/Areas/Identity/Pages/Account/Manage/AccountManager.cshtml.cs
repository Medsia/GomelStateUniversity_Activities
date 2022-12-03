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

namespace GomelStateUniversity_Activity.Areas.Identity.Pages.Account
{
    [Authorize(Roles = "admin")]
    public class AccountManagerModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public AccountManagerModel(
            UserManager<ApplicationUser> userManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Студенты")]
        public IEnumerable<ApplicationUser> Students { get; set; } = Enumerable.Empty<ApplicationUser>();

        [Display(Name = "Руководители")]
        public IEnumerable<ApplicationUser> Supervisors { get; set; } = Enumerable.Empty<ApplicationUser>();


        public class InputModel
        {
            
        }


        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            Students = _userManager.GetUsersInRoleAsync("student").Result.ToArray();
            Supervisors = _userManager.GetUsersInRoleAsync("supervisor").Result.ToArray();
        }


        public void OnPost(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
            
            }
        }
    }
}
