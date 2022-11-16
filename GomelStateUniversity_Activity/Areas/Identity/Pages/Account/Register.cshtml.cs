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

namespace GomelStateUniversity_Activity.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(30, ErrorMessage = "{0} должна быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Фамилия")]
            public string Surname { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} должно быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Имя")]
            public string Name { get; set; }

            [Required]
            [StringLength(30, ErrorMessage = "{0} должно быть минимум {2} символа.", MinimumLength = 3)]
            [Display(Name = "Отчество")]
            public string Patronym { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Номер телефона")]
            public string PhoneNumber { get; set; }


            [Required]
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
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                string username = Input.Name.Normalize().Substring(0, 1) + Input.Patronym.Normalize().Substring(0, 1) + Input.Surname.Normalize();
                var user = new ApplicationUser { 
                    UserName = username,

                    Surname = Input.Surname,
                    Name = Input.Name,
                    Patronym = Input.Patronym,
                    PhoneNumber = Input.PhoneNumber,

                    Email = Input.Email,
                    Faculty = Input.Faculty,
                    Year = Input.Year,
                    Group = Input.Group };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    if (!string.IsNullOrWhiteSpace(user.Email))
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Подтверждение почты",
                            $"Пожалуйста подтвердите вашу почту <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>кликнув здесь</a>.");

                    }

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
