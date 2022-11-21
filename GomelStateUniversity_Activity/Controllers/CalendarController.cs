using GomelStateUniversity_Activity.Models;
using Microsoft.AspNetCore.Authorization;
using GomelStateUniversity_Activity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using GomelStateUniversity_Activity.Helpers;
using Microsoft.AspNetCore.Identity;
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
            //if (TempData["Message"] != null)
            //{
            //    ViewData["Message"] = TempData["Message"];
            //}
            //return View(await _eventRepository.GetMyEventsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetMyEventsAsync(userid).Result);
            //return View();
            return View(await _eventRepository.GetMyEventsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)));
        }
        public async Task<IActionResult> CultureCalendar()
        {
            //if (TempData["Message"] != null)
            //{
            //    ViewData["Message"] = TempData["Message"];
            //}
            //int CultureSubdivisionId = 2;
            //return View(await _eventRepository.GetEventsBySubdivisionAsync(CultureSubdivisionId));
            int CultureSubdivisionId = 2;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(CultureSubdivisionId).Result);
            return View();
        }

        public async Task<IActionResult> SportCalendar()
        {
            //if (TempData["Message"] != null)
            //{
            //    ViewData["Message"] = TempData["Message"];
            //}
            //int SportSubdivisionId = 3;
            //return View(await _eventRepository.GetEventsBySubdivisionAsync(SportSubdivisionId));
            int SportSubdivisionId = 3;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(SportSubdivisionId).Result);
            return View();
        }

        public async Task<IActionResult> MassEventsCalendar()
        {
            //if (TempData["Message"] != null)
            //{
            //    ViewData["Message"] = TempData["Message"];
            //}
            //int MassEventsSubdivisionId = 4;
            //return View(await _eventRepository.GetEventsBySubdivisionAsync(MassEventsSubdivisionId));
            int MassEventsSubdivisionId = 4;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(MassEventsSubdivisionId).Result);
            return View();
        }

        public async Task<IActionResult> VolunteersCalendar()
        {
            //if (TempData["Message"] != null)
            //{
            //    ViewData["Message"] = TempData["Message"];
            //}
            //int VolunteersSubdivisionId = 12;
            //return View(await _eventRepository.GetEventsBySubdivisionAsync(VolunteersSubdivisionId));
            int VolunteersSubdivisionId = 12;
            ViewData["Resources"] = JSONListHelper.GetResourceListJSONString(_subdivisionRepository.GetSubdivisionsAsync().Result);
            ViewData["Events"] = JSONListHelper.GetEventListJSONString(_eventRepository.GetEventsBySubdivisionAsync(VolunteersSubdivisionId).Result);
            return View();
        }
    }
}
