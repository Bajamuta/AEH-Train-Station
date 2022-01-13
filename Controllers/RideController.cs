using System;
using Microsoft.AspNetCore.Mvc;
using TrainStation.Data;

namespace TrainStation.Controllers
{
    public class RideController : Controller
    {
        private TrainStationContext _context;

        public RideController(TrainStationContext context)
        {
            _context = context;
        }

        public IActionResult Edit()
        {
            return View();
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}