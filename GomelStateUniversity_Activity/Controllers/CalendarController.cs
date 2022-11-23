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

        public async Task<IActionResult> MyEventsCalendar()
        {
            if (TempData["Message"] != null)
            {
                ViewData["Message"] = TempData["Message"];
            }
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetMyEventsAsync(userid).Result);
            //return View();
            return View(await _eventRepository.GetMyEventsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        public IActionResult CultureCalendar()
        {

            int CultureSubdivisionId = 2;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(CultureSubdivisionId).Result);
            return View();
        }

        public IActionResult SportCalendar()
        {

            int SportSubdivisionId = 3;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(SportSubdivisionId).Result);
            return View();
        }

        public IActionResult MassEventsCalendar()
        {

            int MassEventsSubdivisionId = 4;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(MassEventsSubdivisionId).Result);
            return View();
        }

        public IActionResult VolunteersCalendar()
        {

            int VolunteersSubdivisionId = 12;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(VolunteersSubdivisionId).Result);
            return View();
        }
    }
}
