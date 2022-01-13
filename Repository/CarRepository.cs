using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Repository
{
    public class CarRepository
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public CarRepository(TrainStationContext context)
        {
            _context = context;
        }
        
        public Task<List<Car>> GetAllCar()
        {
            return _context.Car.ToListAsync();
        }

        public Car GetCarById(int id)
        {
            return _context.Car.FirstOrDefault(v => v.ID == id);
        }

        public Task<List<Car>> SearchCar(Boolean available, int? sitting = null, int? standing = null)
        {
            return _context.Car.Where(v => 
                v.Available == available &&
                (sitting == null || v.Sitting == sitting) &&
                (standing == null || v.Standing == standing)
            ).ToListAsync();
        }
        
    }
}