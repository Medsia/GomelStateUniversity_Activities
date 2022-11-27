using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Helpers;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GomelStateUniversity_Activity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly UserManager<ApplicationUser> _usermanager;

        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository,
            UserManager<ApplicationUser> usermanager)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _subdivisionRepository = subdivisionRepository;
            _usermanager = usermanager;
        }

        public IActionResult Index()
        {
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsAsync().Result);
            return View();
        }

        public IActionResult Privacy() => View();
        public IActionResult About() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ViewResult PageNotFound()
        {
            Response.StatusCode = 404;
            return View();
        }
    }
}
