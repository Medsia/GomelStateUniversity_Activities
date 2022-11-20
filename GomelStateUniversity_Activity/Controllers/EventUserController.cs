using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GomelStateUniversity_Activity.Controllers
{
    public class EventUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Create()
        //{
        //    return View(new EventViewModel(_subdivisionRepository.GetSubdivisionsAsync().Result.ToList()));
        //}
    }
}
