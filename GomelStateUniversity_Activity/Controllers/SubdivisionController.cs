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
    public class SubdivisionController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        public SubdivisionController(IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository)
        {
            _eventRepository = eventRepository;
            _subdivisionRepository = subdivisionRepository;
        }

        // GET: Subdivision
        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _subdivisionRepository.GetSubdivisionsAsync());
        }

        // GET: Subdivision/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _subdivisionRepository.GetSubdivisionAsync((int)id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // GET: Subdivision/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subdivision/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Contacts")] Subdivision subdivision)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _subdivisionRepository.CreateSubdivisionAsync(subdivision);
                    TempData["Message"] = "Подразделение добавлено: " + subdivision.Name;
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

        // GET: Subdivision/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subdivision = await _subdivisionRepository.GetSubdivisionAsync((int)id);
            if (subdivision == null)
            {
                return NotFound();
            }

            return View(subdivision);
        }

        // POST: Subdivision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _subdivisionRepository.DeleteSubdivisionAsync(id);
            TempData["Message"] = "Подразделение удалено.";
            return RedirectToAction(nameof(Index));
        }

    }
}
