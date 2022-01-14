using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class ConductorsController : Controller
    {
        private readonly TrainStationContext _context;
        // private readonly EmployeeController _employeeController;

        public ConductorsController(TrainStationContext context)
        {
            _context = context;
           // _employeeController = new EmployeeController(context);
        }

        /*public IEnumerable<Conductor> GetAllConductorsWithRide()
        {
            return _context.Conductors
                .Include(c => c.Ride)
                .Include(c => c.ConductorEmployee)
                .AsEnumerable();
        }*/

        /*public List<int> GetAllIdsConductorsWithRide()
        {
            List<int> temp = new List<int>();
            foreach (Conductor c in GetAllConductorsWithRide())
            {
                temp.Add(c.ConductorID);
            }
            return temp;
        }*/

        /*public async Task<List<Employee>> GetAllConductorsWithoutRide()
        {
            List<Employee> allConductors = await _employeeController.GetAllConductors();
            List<int> allConductorsWithRideById = GetAllIdsConductorsWithRide();
            List<Employee> temp = new List<Employee>();

            foreach (Employee e in allConductors)
            {
                if (!allConductorsWithRideById.Contains(e.ID))
                {
                    temp.Add(e);
                }
            }

            return temp;
        }*/
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}