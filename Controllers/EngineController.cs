using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Controllers
{
    public class EngineController : Controller
    {
        private readonly TrainStationContext _context;

        public EngineController(TrainStationContext context)
        {
            _context = context;
        }

        public async Task<List<Engine>> GetAllEngines()
        {
            return await _context.Engines
                .Include(e => e.Rides)
                .ToListAsync();
        }

        public async Task<Engine> GetEngineById(int id)
        {
            return await _context.Engines
                .Include(e => e.Rides)
                .FirstAsync(e => e.ID == id);
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}