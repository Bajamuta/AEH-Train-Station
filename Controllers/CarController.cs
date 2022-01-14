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

        /*public Task<List<Car>> SearchCar()
        {
            return _context.Car.Where(v => 
                v.Available == available &&
                (sitting == null || v.Sitting == sitting) &&
                (standing == null || v.Standing == standing)
            ).ToListAsync();
        }*/
        
        public IEnumerable<Car> GetAvailableCar()
        {
            return _context.Car.Where(v => v.Available == true)
                .Include(c => c.Tickets)
                .Include(c => c.Cars)
                .AsEnumerable();
        }

        public void MakeCarAvailable(int id)
        {
            Car c = _context.Car.First(v => v.ID == id);
            c.Available = true;
            _context.Attach(c).State = EntityState.Modified;
        }
        
        public void MakeCarUnavailable(int id)
        {
            Car c = _context.Car.First(v => v.ID == id);
            c.Available = false;
            _context.Attach(c).State = EntityState.Modified;
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