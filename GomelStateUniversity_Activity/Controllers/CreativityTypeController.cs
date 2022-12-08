using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Controllers
{
    [Authorize(Roles = "admin, supervisor, Культурно-досуговая деятельность")]
    public class CreativityTypeController : Controller
    {
        private readonly ICreativityTypeRepository _creativityTypeRepository;
        public CreativityTypeController(ICreativityTypeRepository creativityTypeRepository)
        {
            _creativityTypeRepository = creativityTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _creativityTypeRepository.GetCreativityTypesAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CreativityType creativityType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _creativityTypeRepository.CreateCreativityTypeAsync(creativityType);
                    TempData["Message"] = "Добавлено: " + creativityType.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(creativityType);
                }

            }
            return View(creativityType);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creativityType = await _creativityTypeRepository.GetCreativityTypeAsync((int)id);
            if (creativityType == null)
            {
                return NotFound();
            }

            return View(creativityType);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _creativityTypeRepository.DeleteCreativityTypeAsync(id);
            TempData["Message"] = "Удалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}
