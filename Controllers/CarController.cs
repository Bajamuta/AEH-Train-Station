using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;
using TrainStation.Repository;

namespace TrainStation.Controllers
{
    public class CarController : Controller
    {
        private TrainStationContext _context;

        public CarController(TrainStationContext context)
        {
            _context = context;
        }

        public Task<List<Car>> GetAllCar()
        {
            return _context.Car
                .Include(c => c.Cars)
                .Include(c => c.Tickets)
                .ToListAsync();
        }

        public Car GetCarById(int id)
        {
            return _context.Car
                .Include(c => c.Cars)
                .Include(c => c.Tickets)
                .FirstOrDefault(v => v.ID == id);
        }

        public Task<List<Car>> SearchCar(Boolean available, int? sitting = null, int? standing = null)
        {
            return _context.Car.Where(v => 
                v.Available == available &&
                (sitting == null || v.Sitting == sitting) &&
                (standing == null || v.Standing == standing)
            )
                .Include(c => c.Cars)
                .Include(c => c.Tickets)
                .ToListAsync();
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}