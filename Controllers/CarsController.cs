using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class CarsController : Controller
    {
        private TrainStationContext _context;

        public CarsController(TrainStationContext context)
        {
            _context = context;
        }

        public async Task<List<Cars>> GetAllRideCars()
        {
            return await _context.Cars
                .Include(c => c.Car)
                .Include(c => c.Ride)
                .ToListAsync();
        }

        public async Task<List<Cars>> GetCarsFromRide(int rideId)
        {
            return await _context.Cars.Where(c => c.RideID == rideId)
                .Include(c => c.Car)
                .Include(c => c.Ride)
                .ToListAsync();
        }

        public EntityEntry<Cars> RemoveCarFromRide(int carId)
        {
            Cars c = _context.Cars.First(v => v.CarID == carId);
            _context.Attach(c).State = EntityState.Deleted;
            return _context.Cars.Remove(c);
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}