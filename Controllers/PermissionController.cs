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
    public class PermissionController : Controller
    {
        private readonly TrainStationContext _context;

        public PermissionController(TrainStationContext context)
        {
            _context = context;
        }

        public IEnumerable<Permission> GetAllPermissions()
        {
            return _context.Permissions
                .Include(p => p.Employees)
                .AsEnumerable();
        }
        
        public async Task<Permission> GetByName(string name)
        {
            return await _context.Permissions
                .Include(p => p.Employees)
                .FirstAsync(p => p.Name == name);
        }

        public async Task<Permission> GetConductor()
        {
            return await GetByName("conductor");
        }
        
        public async Task<Permission> GetDriver()
        {
            return await GetByName("driver");
        }

        public async Task<Permission> GetCashier()
        {
            return await GetByName("cashier");
        }

        public async Task<Permission> GetHead()
        {
            return await GetByName("head");
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}