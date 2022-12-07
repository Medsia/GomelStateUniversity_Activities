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

        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UserDetailsModel(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RegisterModel> logger,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _logger = logger;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public ApplicationUser user { get; set; }
        public IEnumerable<IdentityRole> roles { get; set; } = Enumerable.Empty<IdentityRole>();

        public class InputModel
        {
            [Display(Name = "Роль в системе")]
            public string RoleName { get; set; }

            [StringLength(30, ErrorMessage = "{0} должна быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Фамилия")]
            public string Surname { get; set; }

            [StringLength(30, ErrorMessage = "{0} должно быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Имя")]
            public string Name { get; set; }

            [StringLength(30, ErrorMessage = "{0} должно быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Отчество")]
            public string Patronym { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Номер телефона")]
            public string PhoneNumber { get; set; }


            [StringLength(16, ErrorMessage = "{0} должен быть от {2} до {1} символов.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Повторите пароль")]
            [Compare("Password", ErrorMessage = "Введенные пароли не совпадают")]
            public string ConfirmPassword { get; set; }



            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Факультет")]
            public string Faculty { get; set; }

            [Display(Name = "Курс")]
            public int Year { get; set; }

            [Display(Name = "Группа")]
            public string Group { get; set; }


            [HiddenInput]
            public string UserId { get; set; }
        }


        public void OnGet(string userId, string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            user = _userManager.FindByIdAsync(userId).Result;
            roles = _roleManager.Roles.ToArray();
        }


        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                user = _userManager.FindByIdAsync(Input.UserId).Result;
                roles = _roleManager.Roles.ToArray();

                string username = Input.Name.Normalize().Substring(0, 1) + Input.Patronym.Normalize().Substring(0, 1) + Input.Surname.Normalize();

                if(user.Name != Input.Name) user.Name = Input.Name;
                if (user.Surname != Input.Surname) user.Surname = Input.Surname;
                if (user.Patronym != Input.Patronym) user.Patronym = Input.Patronym;
                if (user.Group != Input.Group) user.Group = Input.Group;
                if (user.Year != Input.Year) user.Year = Input.Year;
                if (user.Faculty != Input.Faculty) user.Faculty = Input.Faculty;
                if (user.PhoneNumber != Input.PhoneNumber) user.PhoneNumber = Input.PhoneNumber;
                if (user.Email != Input.Email) user.Email = Input.Email;

                if (!string.IsNullOrWhiteSpace(Input.Password))
                {
                    string hashedPass = _passwordHasher.HashPassword(user, Input.Password);
                    if (user.PasswordHash != hashedPass) user.PasswordHash = hashedPass;
                }
                
                var result = await _userManager.UpdateAsync(user);

                if(Input.RoleName != "STUDENT")
                {
                    await _userManager.RemoveFromRoleAsync(user, "STUDENT");
                    await _userManager.AddToRoleAsync(user, Input.RoleName);
                    await _userManager.AddToRoleAsync(user, "SUPERVISOR");
                }
                else
                {
                    await _userManager.RemoveFromRolesAsync(user, roles.Select(r => r.NormalizedName));
                    await _userManager.AddToRoleAsync(user, "student");
                }

                return RedirectToPage("AccountManager");
            }

            return Page();
        }
    }
}
