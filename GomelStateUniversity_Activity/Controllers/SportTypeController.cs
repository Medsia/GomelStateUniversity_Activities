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
    [Authorize(Roles = "admin, supervisor, Спортивные мероприятия")]
    public class SportTypeController : Controller
    {
        private readonly ISportTypeRepository _sportTypeRepository;
        public SportTypeController(ISportTypeRepository sportTypeRepository)
        {
            _sportTypeRepository = sportTypeRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _sportTypeRepository.GetSportTypesAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] SportType sportType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _sportTypeRepository.CreateSportTypeAsync(sportType);
                    TempData["Message"] = "Добавлено: " + sportType.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(sportType);
                }

            }
            return View(sportType);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sportType = await _sportTypeRepository.GetSportTypeAsync((int)id);
            if (sportType == null)
            {
                return NotFound();
            }

            return View(sportType);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sportTypeRepository.DeleteSportTypeAsync(id);
            TempData["Message"] = "Удалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}
