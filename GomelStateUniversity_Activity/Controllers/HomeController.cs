using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Authorization;
﻿using GomelStateUniversity_Activity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GomelStateUniversity_Activity.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;

        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _subdivisionRepository = subdivisionRepository;
        }

        public IActionResult Index()
        {
            var myEvent = _eventRepository.GetEventAsync(1);
            return View();
        }

        public IActionResult Culture() => View();

        public IActionResult Sport() => View();

        public IActionResult MassEvents() => View();

        public IActionResult Volunteers() => View();

        public IActionResult Psychologist() => View();


        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
