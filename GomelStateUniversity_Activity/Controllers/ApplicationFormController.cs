using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public ApplicationFormController(IApplicationFormRepository applicationFormRepository, ISportTypeRepository sportTypeRepository,
            ICreativityTypeRepository creativityTypeRepository, ILaborDirectionRepository laborDirectionRepository,
            ISubdivisionActivityTypeRepository subdivisionActivityTypeRepository)
        {
            _applicationFormRepository = applicationFormRepository;
            _creativityTypeRepository = creativityTypeRepository;
            _sportTypeRepository = sportTypeRepository;
            _laborDirectionRepository = laborDirectionRepository;
            _subdivisionActivityTypeRepository = subdivisionActivityTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _applicationFormRepository.GetApplicationFormsAsync());
        }

        public async Task<IActionResult> UserApplications()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _applicationFormRepository.GetApplicationFormsByUserIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
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
                try
                {
                    await _applicationFormRepository.CreateApplicationFormAsync(form, viewModel.SubdivId,
                        viewModel.ActivityId, User.FindFirstValue(ClaimTypes.NameIdentifier));
                    TempData["Message"] = "Заявка Отправлена ";
                    return RedirectToAction("MyEvents", "Event");
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
