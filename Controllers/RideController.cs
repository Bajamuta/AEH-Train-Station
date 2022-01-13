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

        public void UpdateRideCars()
        {
            Console.WriteLine("UPDATE RIDE CARS");
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}