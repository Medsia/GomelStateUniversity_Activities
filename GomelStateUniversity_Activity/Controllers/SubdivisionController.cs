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
    public class SubdivisionController : Controller
    {
        private readonly ISubdivisionRepository _subdivisionRepository;
        public SubdivisionController(ISubdivisionRepository subdivisionRepository)
        {
            _subdivisionRepository = subdivisionRepository;
        }


        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _subdivisionRepository.GetSubdivisionsAsync());
        }


        [Authorize(Roles = "admin, supervisor")]
        public IActionResult Edit()
        {
            return View();
        }


        [Authorize(Roles = "admin, supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,Contacts")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _subdivisionRepository.UpdateSubdivisionAsync(subdivision);
                    TempData["Message"] = "Контакты отдела обновлениы: " + subdivision.Name;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "Произошла ошибка: " + ex.Message;
                    return View(subdivision);
                }

            }
            return View(subdivision);
        }
    }
}
