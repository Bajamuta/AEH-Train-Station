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
        /*private readonly int _driverId;
        private readonly int _conductorId;
        private readonly int _cashierId;
        private readonly int _headId;*/

        public EmployeeController(TrainStationContext context)
        {
            _context = context;
            /*var permissionController = new PermissionController(context);
            _driverId = permissionController.GetDriver().Id;
            _conductorId = permissionController.GetConductor().Id;
            _cashierId = permissionController.GetCashier().Id;
            _headId = permissionController.GetHead().Id;*/
        }

        /*public async Task<List<Employee>> GetEmployeesByPermission(int permissionId)
        {
            return await _context.Employees
                .Include(e => e.Rides)
                .Include(e => e.Conductors)
                .Where(e => e.PermissionID == permissionId)
                .ToListAsync();
        }
        
        public async Task<Employee> GetEmployeesByPermissionById(int permissionId, int employeeId)
        {
            return await _context.Employees
                .Include(e => e.Rides)
                .Include(e => e.Conductors)
                .Where(e => e.PermissionID == permissionId)
                .FirstAsync(e => e.ID == employeeId);
        }

        public async Task<List<Employee>> GetAllDrivers()
        {
            return await GetEmployeesByPermission(_driverId);
        }

        public async Task<Employee> GetDriverById(int id)
        {
            return await GetEmployeesByPermissionById(_driverId, id);
        }

        public async Task<List<Employee>> GetAllConductors()
        {
            return await GetEmployeesByPermission(_conductorId);
        }
        
        public async Task<Employee> GetConductorById(int id)
        {
            return await GetEmployeesByPermissionById(_conductorId, id);
        }
        
        public async Task<List<Employee>> GetAllCashiers()
        {
            return await GetEmployeesByPermission(_cashierId);
        }
        
        public async Task<Employee> GetCashierById(int id)
        {
            return await GetEmployeesByPermissionById(_cashierId, id);
        }
        
        public async Task<List<Employee>> GetAllHeads()
        {
            return await GetEmployeesByPermission(_headId);
        }
        
        public async Task<Employee> GetHeadById(int id)
        {
            return await GetEmployeesByPermissionById(_headId, id);
        }*/
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}