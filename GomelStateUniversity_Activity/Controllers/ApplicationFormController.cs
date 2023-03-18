using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.Notifications;
using GomelStateUniversity_Activity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static GomelStateUniversity_Activity.Data.ApplicationFormRepository;
using static GomelStateUniversity_Activity.Data.SubdivisionRepository;

namespace GomelStateUniversity_Activity.Controllers
{
    public class ApplicationFormController : Controller
    {
        private readonly IApplicationFormRepository _applicationFormRepository;
        private readonly ISportTypeRepository _sportTypeRepository;
        private readonly ICreativityTypeRepository _creativityTypeRepository;
        private readonly ILaborDirectionRepository _laborDirectionRepository;
        private readonly ISubdivisionActivityTypeRepository _subdivisionActivityTypeRepository;
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;
        public ApplicationFormController(IApplicationFormRepository applicationFormRepository, ISportTypeRepository sportTypeRepository,
            ICreativityTypeRepository creativityTypeRepository, ILaborDirectionRepository laborDirectionRepository,
            ISubdivisionActivityTypeRepository subdivisionActivityTypeRepository, INotificationService notificationService,
            UserManager<ApplicationUser> userManager)
        {
            _applicationFormRepository = applicationFormRepository;
            _creativityTypeRepository = creativityTypeRepository;
            _sportTypeRepository = sportTypeRepository;
            _laborDirectionRepository = laborDirectionRepository;
            _subdivisionActivityTypeRepository = subdivisionActivityTypeRepository;
            _notificationService = notificationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _applicationFormRepository.GetApplicationFormsAsync());
        }

        public async Task<IActionResult> UserApplications(int page = 0)
        {
            const int PageSize = 3;

            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            var userApplications = await _applicationFormRepository.GetApplicationFormsByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var count = userApplications.Count();

            var pagedUserApplications = userApplications.Skip(page * PageSize).Take(PageSize).ToList();

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;

            return View(pagedUserApplications);
        }

        public IActionResult Create(int subdivId, int activityId)
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            if (subdivId == (int)SubdivisionName.Culture)
            {
                if(activityId == (int)Activity.Organizer)
                    return View(new ApplicationFormViewModel(_subdivisionActivityTypeRepository.GetSubdivisionActivityTypeAsync(activityId).Result.Name, subdivId, activityId));
                else if (activityId == (int)Activity.Participant)
                    return View(new ApplicationFormViewModel(_creativityTypeRepository.GetCreativityTypesAsync().Result.ToList(), subdivId, activityId));
                else
                    return NotFound();
            }
                
            else if (subdivId == (int)SubdivisionName.Sport)
                return View(new ApplicationFormViewModel(_sportTypeRepository.GetSportTypesAsync().Result.ToList(), subdivId, activityId));

            else if (subdivId == (int)SubdivisionName.Labor)
            {
                if (activityId == (int)Activity.Organizations)
                    return View(new ApplicationFormViewModel(Data.Data.Organization.organizationsData, subdivId, activityId));
                else if (activityId == (int)Activity.Labor)
                    return View(new ApplicationFormViewModel(_laborDirectionRepository.GetLaborDirectionsAsync().Result.ToList(), subdivId, activityId));
                else
                    return NotFound();
            }
                
            else
                return NotFound();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationFormViewModel viewModel, IFormCollection form)
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            try
                {
                    var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                    await _applicationFormRepository.CreateApplicationFormAsync(form, viewModel.SubdivId,
                        viewModel.ActivityId, user.Id);

                    var recepientUsers = new List<ApplicationUser>();
                    string messageText = string.Empty;

                if (viewModel.SubdivId == (int)SubdivisionName.Culture)
                {
                    if (viewModel.ActivityId == (int)Activity.Participant)
                        messageText += "Артист: ";

                    recepientUsers = await _userManager.GetUsersInRoleAsync("CULTURE") as List<ApplicationUser>;
                }
                    

                else if (viewModel.SubdivId == (int)SubdivisionName.Sport)
                {
                    recepientUsers = await _userManager.GetUsersInRoleAsync("SPORTS") as List<ApplicationUser>;
                    messageText += "Запись в секцию: ";
                }
                    

                else if (viewModel.SubdivId == (int)SubdivisionName.Labor)
                {
                    if(form["ActivityType"] == "Профсоюз")
                    {
                        recepientUsers = await _userManager.GetUsersInRoleAsync("UNION") as List<ApplicationUser>;
                        messageText += "Заявка на вступление: ";
                    }

                    else
                    {
                        if (viewModel.ActivityId == (int)Activity.Labor)
                            messageText += " Заявка на работу: ";
                        else if (viewModel.ActivityId == (int)Activity.Organizations)
                            messageText += "Заявка на вступление: ";
                        recepientUsers = await _userManager.GetUsersInRoleAsync("VOLUNTEER") as List<ApplicationUser>;
                    }               
                }

                messageText += form["ActivityType"] + '-';

                if (viewModel.ActivityTypeName != null)
                    messageText += viewModel.ActivityTypeName;

                messageText += " Студент: " + user.FullName;
                messageText += " Телефон: " + user.PhoneNumber;

                if(viewModel.DateTime != null)
                    messageText += " Дата: " + viewModel.DateTime;

                foreach (ApplicationUser recepientUser in recepientUsers)
                {
                    if(recepientUser.Email != null)
                        await _notificationService.SendAsync(recepientUser.Email,
                            "Новая Заявка", messageText);
                }


                    TempData["Message"] = "Заявка Отправлена ";
                    return RedirectToAction(nameof(UserApplications));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(viewModel);
                }

        }
        public async Task<IActionResult> CancelParticipation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForm = await _applicationFormRepository.GetApplicationFormAsync((int)id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            return View(applicationForm);
        }

        [HttpPost, ActionName("CancelParticipation")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelParticipationConfirmed(int id, string reason)
        {
            try
            {
                await _applicationFormRepository.CancelParticipationAsync(id, 
                    User.FindFirstValue(ClaimTypes.NameIdentifier), reason);
                TempData["Message"] = "Ваше участие отменено.";                
            }

            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }

            return RedirectToAction(nameof(UserApplications));
        }

        [Authorize(Roles = "admin, supervisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationForm = await _applicationFormRepository.GetApplicationFormAsync((int)id);
            if (applicationForm == null)
            {
                return NotFound();
            }

            return View(applicationForm);
        }

        [Authorize(Roles = "admin, supervisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _applicationFormRepository.DeleteApplicationFormAsync(id);
            TempData["Message"] = "Удалено.";
            return RedirectToAction(nameof(Index));
        }


    }
}
