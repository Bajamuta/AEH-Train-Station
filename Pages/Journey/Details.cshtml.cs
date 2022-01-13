using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Journey
{
    public class DetailsModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public DetailsModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public Models.Journey Journey { get; set; }
        public Models.Ride Ride { get; set; }
        public ICollection<Cars> Cars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journey = await _context.Journeys
                .Include(j => j.DestinationPlace)
                .Include(j => j.StartingPlace)
                .Include(j => j.Status)
                .Include(j => j.Ride)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Journey == null)
            {
                return NotFound();
            }
            
            Ride = await _context.Rides
                .Include(d => d.Driver)
                .Include(d => d.Cars)
                .Include(d => d.Conductors)
                .Include(d => d.Engine)
                .FirstOrDefaultAsync(r => r.ID == Journey.RideId);

            Cars = await _context.Cars
                .Include(c => c.Car)
                .Include(c => c.Ride)
                .ToListAsync();
            
            Console.WriteLine(Cars);
            
            /*Cars = await _context.Car
                .Include(c => c.ID)
                .Include(c => c.Name)
                .Include(c => c.Sitting)
                .Include(c => c.Standing)
                .Include(c => c.Available)
                .FirstOrDefaultAsync(c => c)*/
            
            return Page();
        }
    }
}
