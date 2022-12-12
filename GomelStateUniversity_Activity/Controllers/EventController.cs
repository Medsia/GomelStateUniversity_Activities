using GomelStateUniversity_Activity.Data;
using GomelStateUniversity_Activity.Models;
using GomelStateUniversity_Activity.Notifications;
using GomelStateUniversity_Activity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly IEventUserRepository _eventUserRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _userManager;
        public string WebRootPath { private get; set; }

        public EventController(IEventRepository eventRepository, ISubdivisionRepository subdivisionRepository,
            IEventUserRepository eventUserRepository, IImageRepository imageRepository,
            IWebHostEnvironment appEnvironment, IScheduleRepository scheduleRepository,
            INotificationService notificationService, UserManager<ApplicationUser> userManager)
        {
            _eventRepository = eventRepository;
            _subdivisionRepository = subdivisionRepository;
            _eventUserRepository = eventUserRepository;
            _imageRepository = imageRepository;
            WebRootPath = appEnvironment.WebRootPath;
            _scheduleRepository = scheduleRepository;
            _notificationService = notificationService;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index(bool Irrelevant = false)
        {
            if (TempData["Message"] != null) ViewData["Message"] = TempData["Message"];

            if (Irrelevant) ViewBag.PageName = "Cписок прошлых мероприятий";
            else ViewBag.PageName = "Cписок мероприятий";

            ViewBag.Irrelevant = Irrelevant;

            var events = await _eventRepository.GetEventsAsync();

            if (Irrelevant)
                return View(events.Where(x => x.DateTime < DateTime.Now));
            else
                return View(events.Where(x => x.DateTime > DateTime.Now));
        }

        public async Task<IActionResult> Exhibitions()
        {
            if (TempData["Message"] != null) ViewData["Message"] = TempData["Message"];

            ViewBag.PageName = "Выставки";

            var exhibitions = await _eventRepository.GetExhibitionsAsync();

            return View(exhibitions);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null) return NotFound();

            return View(@event);
        }
        public async Task<IActionResult> ExhibitionDetails(int? id)
        {
            if (id == null) return NotFound();

            var exhibition = await _eventRepository.GetEventAsync((int)id);
            if (exhibition == null) return NotFound();

            IEnumerable<ScheduleItem> daySchedule = await _scheduleRepository.GetItemsBySubdivIdAsync(3);
            daySchedule = daySchedule.Where(x => x.DateTime.Day == exhibition.DateTime.Day);

            ViewBag.DaySchedule = daySchedule;

            return View(exhibition);
        }


        [Authorize(Roles = "admin, supervisor")]
        public IActionResult Create(int subdivId = 0)
        {
            if(subdivId == 0) return View(new EventViewModel(_subdivisionRepository.GetSubdivisionsAsync().Result.ToList()));
            else return View(new EventViewModel(_subdivisionRepository.GetSubdivisionAsync(subdivId).Result));
        }


        [Authorize(Roles = "admin, supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel viewModel, IFormCollection form, IFormFile PosterImage)
        {
            try
            {
                string imgPath = "";
                if (PosterImage != null)
                {
                    imgPath = "/Img/" + Guid.NewGuid().ToString() + PosterImage.FileName;
                    string fullPath = WebRootPath + imgPath;
                    await _imageRepository.SaveImageAsync(PosterImage, fullPath);
                }

                await _eventRepository.CreateEventAsync(form, imgPath);

                TempData["Message"] = "Событие добавлено: " + form["Event.Name"];

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Произошла ошибка: " + ex.Message;
                return View(viewModel);
            }
        }

        [Authorize(Roles = "admin, supervisor")]
        public IActionResult CreateExhibition(int subdivId = 0)
        {
            if (subdivId == 0) return View(new EventViewModel(_subdivisionRepository.GetSubdivisionsAsync().Result.ToList()));
            else return View(new EventViewModel(_subdivisionRepository.GetSubdivisionAsync(subdivId).Result));
        }

        [Authorize(Roles = "admin, supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExhibition(EventViewModel viewModel, IFormCollection form, IFormFile PosterImage, 
            string location, string openingTime, DateTime dateTimeEnd, string description)
        {
            try
            {
                string imgPath = "";
                if (PosterImage != null)
                {
                    imgPath = "/Img/" + Guid.NewGuid().ToString() + PosterImage.FileName;
                    string fullPath = WebRootPath + imgPath;
                    await _imageRepository.SaveImageAsync(PosterImage, fullPath);
                }

                description += " Место проведения: " + location ;
                description += " Время открытия: " + openingTime;
                description += " Дата окончания: " + dateTimeEnd;

                await _eventRepository.CreateEventAsync(form, imgPath, description);

                TempData["Message"] = "Выставка добавлена: " + form["Event.Name"];

                return RedirectToAction(nameof(Exhibitions));
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Произошла ошибка: " + ex.Message;
                return View(viewModel);
            }
        }

        [Authorize(Roles = "admin, supervisor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null) return NotFound();

            var viewModel = new EventViewModel(@event, _subdivisionRepository.GetSubdivisionsAsync().Result.ToList());
            return View(viewModel);
        }


        [Authorize(Roles = "admin, supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form, IFormFile PosterImage)
        {
            try
            {
                string imgPath = "";
                if (PosterImage != null)
                {
                    imgPath = "/Img/" + Guid.NewGuid().ToString() + PosterImage.FileName;
                    string fullPath = WebRootPath + imgPath;

                    if (string.IsNullOrWhiteSpace(form["Event.OldImg"]))
                    {
                        await _imageRepository.SaveImageAsync(PosterImage, fullPath);
                    }
                    else
                    {
                        string oldPath = WebRootPath + form["Event.OldImg"];
                        await _imageRepository.EditImageAsync(PosterImage, fullPath, oldPath);
                    }
                }
                else imgPath = form["Event.OldImg"];

                await _eventRepository.UpdateEventAsync(form, imgPath);

                TempData["Message"] = "Данные для: " + form["Event.Name"] + "изменены.";
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["Message"] = "Произошла ошибка: " + ex.Message;
                var viewModel = new EventViewModel(_eventRepository.GetEventAsync(id).Result, _subdivisionRepository.GetSubdivisionsAsync().Result.ToList());
                return View(viewModel);
            }
        }


        [Authorize(Roles = "admin, supervisor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var @event = await _eventRepository.GetEventAsync((int)id);
            if (@event == null) return NotFound();

            return View(@event);
        }


        [Authorize(Roles = "admin, supervisor")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singleEvent = await _eventRepository.GetEventAsync(id);
            if (!string.IsNullOrWhiteSpace(singleEvent.PosterPath))
            {
                string fullPath = WebRootPath + singleEvent.PosterPath;
                _imageRepository.DeleteImage(fullPath);
            }

            var eventUsers = await _eventUserRepository.GetEventUsersByEventId(id);
            await _eventRepository.DeleteEventAsync(id);

            foreach(EventUser eventUser in eventUsers)
            {
                await _notificationService.SendAsync(eventUser.ApplicationUser.Email, "Мероприятие отменено", eventUser.Event.Name + " отменено" );
            }            
            TempData["Message"] = "Событие удалено. ";
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Subscribe(int? id, int subdivId, int selectedHour)
        {
            if (id == null) return NotFound();

            try
            {
                await _eventUserRepository.SubscribeUserAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier));


                TempData["Message"] = "Вы записались. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UnSubscribe(int? id, int subdivId)
        {
            if (id == null) return NotFound();
            try
            {

                await _eventUserRepository.UnSubscribeUserAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier));
                TempData["Message"] = "Вы отписались. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> SubscribeGroup(int? id, int ticketsAmount, int subdivId, int selectedHour)
        {
            if (id == null) return NotFound();

            try
            {
                await _eventUserRepository.SubscribeUserGroupAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier), ticketsAmount);

                TempData["Message"] = "Группа записана. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> SubscribeOnExhibition(int? id, int subdivId, int selectedHour)
        {
            if (id == null) return NotFound();

            try
            {
                await _eventUserRepository.SubscribeUserOnExhibitionAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier));

                if (subdivId == 3)
                {
                    Dictionary<string, Microsoft.Extensions.Primitives.StringValues> formData = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                    {
                        { "UserName", User.Identity.Name },
                        { "SubdivId", "3" },
                    };

                    var selectedDateTime = (await _eventRepository.GetEventAsync((int)id)).DateTime.Date;
                    selectedDateTime = selectedDateTime.AddHours(selectedHour);

                    FormCollection form = new FormCollection(formData);

                    await _scheduleRepository.CreateItemAsync(form, selectedDateTime);
                }

                var recepientUsers = await _userManager.GetUsersInRoleAsync("EXHIBITION");

                var student = _userManager.FindByNameAsync(User.Identity.Name).Result;

                var @event = await _eventRepository.GetEventAsync((int)id);

                foreach (ApplicationUser recepientUser in recepientUsers)
                {
                    await _notificationService.SendAsync(recepientUser.Email, "Запись на выставку",
                        @event.Name + " Данные студента: " + student.FullName + student.PhoneNumber + " записался");
                }
                TempData["Message"] = "Вы записались. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }

            return RedirectToAction(nameof(Exhibitions));
        }


        public async Task<IActionResult> UnSubscribeFromExhibition(int? id, int subdivId)
        {
            if (id == null) return NotFound();
            try
            {
                if (subdivId == 3)
                {
                    var selectedEvent = await _eventRepository.GetEventAsync((int)id);
                    var items = await _scheduleRepository.GetItemsByDateAsync(selectedEvent.DateTime);
                    var item = items.SingleOrDefault(i => i.ApplicationUser.UserName == User.Identity.Name);

                    if(item != null)
                        await _scheduleRepository.DeleteItemAsync(item.Id);
                }

                await _eventUserRepository.UnSubscribeUserFromExhibitionAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier));
                TempData["Message"] = "Вы отписались. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }

            return RedirectToAction(nameof(Exhibitions));
        }


        [HttpPost]
        public async Task<IActionResult> SubscribeGroupOnExhibition(int? id, int ticketsAmount, int subdivId, int selectedHour)
        {
            if (id == null) return NotFound();

            try
            {
                await _eventUserRepository.SubscribeUserGroupOnExhibitionAsync((int)id, User.FindFirstValue(ClaimTypes.NameIdentifier), ticketsAmount);

                if (subdivId == 3)
                {
                    Dictionary<string, Microsoft.Extensions.Primitives.StringValues> formData = new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
                    {
                        { "UserName", User.Identity.Name },
                        { "SubdivId", "3" },
                    };

                    var selectedDateTime = (await _eventRepository.GetEventAsync((int)id)).DateTime.Date;
                    selectedDateTime = selectedDateTime.AddHours(selectedHour);

                    FormCollection form = new FormCollection(formData);

                    await _scheduleRepository.CreateItemAsync(form, selectedDateTime);
                }
                var recepientUsers = await _userManager.GetUsersInRoleAsync("EXHIBITION");

                var student = _userManager.FindByNameAsync(User.Identity.Name).Result;

                var @event = await _eventRepository.GetEventAsync((int)id);

                foreach (ApplicationUser recepientUser in recepientUsers)
                {
                    await _notificationService.SendAsync(recepientUser.Email, "Запись на выставку",
                        @event.Name + " Данные студента: " + student.FullName + student.PhoneNumber + " Количество: " + ticketsAmount);
                }
                TempData["Message"] = "Группа записана. ";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Операция невозможна. " + ex.Message;
            }
            return RedirectToAction(nameof(Exhibitions));
        }

        public async Task<IActionResult> MyEvents()
        {
            if (TempData["Message"] != null) ViewData["Message"] = TempData["Message"];

            ViewBag.PageName = "Мой список мероприятий";
            ViewBag.Irrelevant = true;

            var events = await _eventRepository.GetMyEventsAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return View("Index", events.Where(x => x.DateTime > DateTime.Now));
        }

        public async Task<IActionResult> EventsListForSubdiv(int subdivId, bool Irrelevant = false)
        {
            if (TempData["Message"] != null) ViewData["Message"] = TempData["Message"];

            var subdiv = await _subdivisionRepository.GetSubdivisionAsync(subdivId);

            var events = await _eventRepository.GetEventsBySubdivisionAsync(subdivId);

            if (Irrelevant) ViewBag.PageName = "Список прошлых мероприятий - " + subdiv.Name;
            else ViewBag.PageName = "Список мероприятий - " + subdiv.Name;

            ViewBag.SubdivId = subdivId;
            ViewBag.Irrelevant = Irrelevant;

            if (Irrelevant)
                return View("Index", events.Where(x => x.DateTime < DateTime.Now));
            else
                return View("Index", events.Where(x => x.DateTime > DateTime.Now));
        }

        [Authorize(Roles = "admin, supervisor")]
        public async Task<IActionResult> EventParticipants(int? id)
        {
            if (id == null) return NotFound();

            var @eventUsers = await _eventUserRepository.GetEventUsersByEventId((int)id);
            if (@eventUsers == null) return NotFound();

            return View(@eventUsers);
        }

    }
}
