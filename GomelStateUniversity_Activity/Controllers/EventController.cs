using GomelStateUniversity_Activity.Data;
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
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        public EventController(IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository)
        {
            _eventRepository = eventRepository;
            _subdivisionRepository = subdivisionRepository;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            return View(await _eventRepository.GetEventsAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View(new EventViewModel(_subdivisionRepository.GetSubdivisionsAsync().Result.ToList()));
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel viewModel, IFormCollection form)
        {
            try
            {
                await _eventRepository.CreateEventAsync(form);
                TempData["Message"] = "Событие добавлено: " + form["Event.Name"];
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Произошла ошибка: " + ex.Message;
                return View(viewModel);
            }
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null)
            {
                return NotFound();
            }
            var viewModel = new EventViewModel(@event, _subdivisionRepository.GetSubdivisionsAsync().Result.ToList());
            return View(viewModel);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {

            try
            {
                await _eventRepository.UpdateEventAsync(form);
                TempData["Message"] = "Данные для: " + form["Event.Name "] + "изменены.";
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["Message"] = "Произошла ошибка: " + ex.Message;
                var viewModel = new EventViewModel(_eventRepository.GetEventAsync(id).Result, _subdivisionRepository.GetSubdivisionsAsync().Result.ToList());
                return View(viewModel);
            }
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventRepository.DeleteEventAsync(id);
            TempData["Message"] = "Событие удалено.";
            return RedirectToAction(nameof(Index));
        }
    }
}
