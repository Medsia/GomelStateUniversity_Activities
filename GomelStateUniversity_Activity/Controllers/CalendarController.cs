using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Helpers;
using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly UserManager<ApplicationUser> _usermanager;


        public CalendarController(IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository,
            UserManager<ApplicationUser> usermanager)
        {
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


        public IActionResult MyEventsCalendar()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.PageName = "Мой календарь";

            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetMyEventsAsync(userid).Result);
            return View("Calendar");
        }


        public async Task<IActionResult> CalendarForSubdiv(int subdivId)
        {
            if (subdivId == 0) return RedirectToAction("MyEventsCalendar");

            var subdiv = await _subdivisionRepository.GetSubdivisionAsync(subdivId);
            ViewBag.PageName = "Календарь мероприятий - " + subdiv.Name;
            ViewBag.SubdivId = subdivId;

            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(subdivId).Result);
            return View("Calendar");
        }
    }
}
