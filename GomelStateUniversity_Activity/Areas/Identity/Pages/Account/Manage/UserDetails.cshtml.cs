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
    public class UserDetailsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public UserDetailsModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public ApplicationUser user { get; set; }
        public IEnumerable<IdentityRole> roles { get; set; } = Enumerable.Empty<IdentityRole>();

        public class InputModel
        {
            [Required]
            [Display(Name = "���� � �������")]
            public string RoleId { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} ������ ���� ������� {2} �������.", MinimumLength = 3)]
            [Display(Name = "�������")]
            public string Surname { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} ������ ���� ������� {2} �������.", MinimumLength = 3)]
            [Display(Name = "���")]
            public string Name { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} ������ ���� ������� {2} �������.", MinimumLength = 3)]
            [Display(Name = "��������")]
            public string Patronym { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "����� ��������")]
            public string PhoneNumber { get; set; }


            [Required]
            [StringLength(16, ErrorMessage = "{0} ������ ���� �� {2} �� {1} ��������.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "������")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "��������� ������")]
            [Compare("Password", ErrorMessage = "��������� ������ �� ���������")]
            public string ConfirmPassword { get; set; }



            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "���������")]
            public string Faculty { get; set; }

            [Display(Name = "����")]
            public int Year { get; set; }

            [Display(Name = "������")]
            public string Group { get; set; }
        }


        public void OnGet(string userId, string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            user = _userManager.FindByIdAsync(userId).Result;
            roles = _roleManager.Roles.ToArray();
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
