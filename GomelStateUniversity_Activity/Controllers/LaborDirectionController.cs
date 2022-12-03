using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Controllers
{
    public class LaborDirectionController : Controller
    {
        private readonly ILaborDirectionRepository _laborDirectionRepository;
        public LaborDirectionController(ILaborDirectionRepository laborDirectionRepository)
        {
            _laborDirectionRepository = laborDirectionRepository;
        }

        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _laborDirectionRepository.GetLaborDirectionsAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborDirection = await _laborDirectionRepository.GetLaborDirectionAsync((int)id);
            if (laborDirection == null)
            {
                return NotFound();
            }

            return View(laborDirection);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] LaborDirection laborDirection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _laborDirectionRepository.CreateLaborDirectionAsync(laborDirection);
                    TempData["Message"] = "Добавлено: " + laborDirection.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(laborDirection);
                }

            }
            return View(laborDirection);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laborDirection = await _laborDirectionRepository.GetLaborDirectionAsync((int)id);
            if (laborDirection == null)
            {
                return NotFound();
            }

            return View(laborDirection);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _laborDirectionRepository.DeleteLaborDirectionAsync(id);
            TempData["Message"] = "Удалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}
