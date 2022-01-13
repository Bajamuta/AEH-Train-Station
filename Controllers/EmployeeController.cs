using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class EmployeeController : Controller
    {
        private TrainStationContext _context;
        private int driverId;

        public EmployeeController(TrainStationContext context)
        {
            _context = context;
            driverId = _context.Permissions
                .Include(p => p.Employees)
                .First(p => p.Name == "driver").ID;
        }

        public async Task<List<Employee>> GetAllDrivers()
        {
            return await _context.Employees
                .Include(e => e.Rides)
                .Include(e => e.Conductors)
                .Where(e => e.PermissionID == driverId)
                .ToListAsync();
        }

        public async Task<Employee> GetDriverById(int id)
        {
            return await _context.Employees
                .Include(e => e.Rides)
                .Include(e => e.Conductors)
                .Where(e => e.PermissionID == driverId)
                .FirstAsync(e => e.ID == id);
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}