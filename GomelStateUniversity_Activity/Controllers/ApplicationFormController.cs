using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Details(int? id)
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

        public IActionResult Create(int subdivId, int activityId)
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            if (subdivId == 1)
            {
                if(activityId == 1)
                    return View(new ApplicationFormViewModel(_subdivisionActivityTypeRepository.GetSubdivisionActivityTypeAsync(activityId).Result.Name, subdivId, activityId));
                else if (activityId == 2)
                    return View(new ApplicationFormViewModel(_creativityTypeRepository.GetCreativityTypesAsync().Result.ToList(), subdivId, activityId));
                else
                    return NotFound();
            }
                
            else if (subdivId == 2)
                return View(new ApplicationFormViewModel(_sportTypeRepository.GetSportTypesAsync().Result.ToList(), subdivId, activityId));

            else if (subdivId == 4)
            {
                if (activityId == 4)
                    return View(new ApplicationFormViewModel(Data.Data.Organization.organizationsData, subdivId, activityId));
                else if (activityId == 5)
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
                    await _applicationFormRepository.CreateApplicationFormAsync(form, viewModel.SubdivId, viewModel.ActivityId);
                    TempData["Message"] = "Заявка Отправлена ";
                    return RedirectToAction("MyEvents", "Event");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(viewModel);
                }

        }


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
