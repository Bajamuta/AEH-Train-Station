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
        public int NumberOfTickets { get; set; }

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
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Journey == null)
            {
                return NotFound();
            }
            
            Ride = await _context.Rides
                .Include(d => d.Driver)
                .Include(d => d.Cars)
                .Include(d => d.Conductors)
                .ThenInclude(c => c.ConductorEmployee)
                .Include(d => d.Engine)
                .AsSplitQuery()
                .FirstOrDefaultAsync(r => r.ID == Journey.RideId);

            Cars = await _context.Cars
                .Include(c => c.Car)
                .ThenInclude(c => c.Tickets)
                .Include(c => c.Ride)
                .ToListAsync();

            NumberOfTickets = 0;

            await _context.Cars
                .Include(c => c.Car)
                .Select(c => c.Car)
                .ForEachAsync(x =>
                {
                    NumberOfTickets += x.Sitting + x.Standing;
                });

            return Page();
        }
    }
}
