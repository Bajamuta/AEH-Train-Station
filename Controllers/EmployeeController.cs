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
        private readonly TrainStationContext _context;

        public EmployeeController(TrainStationContext context)
        {
            _context = context;
        }
        
        public void UpdateEmployee(int id)
        {
            Employee e = _context.Employees.First(e => e.ID == id);
            _context.Attach(e).State = EntityState.Modified;
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}