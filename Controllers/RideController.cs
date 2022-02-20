using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class RideController : Controller
    {
        private TrainStationContext _context;

        public RideController(TrainStationContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
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