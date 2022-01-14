using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class ConductorsController : Controller
    {
        private readonly TrainStationContext _context;

        public ConductorsController(TrainStationContext context)
        {
            _context = context;
        }
        
        public EntityEntry<Conductor> AddConductorToRide(int employeeId, int rideId)
        {
            Console.WriteLine("ADDING NEW CARS-RIDE " + employeeId + " " + rideId);
            Conductor c = new Conductor {ConductorID = employeeId, RideID = rideId};
            _context.Attach(c).State = EntityState.Added;
            return _context.Conductors.Add(c);
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}