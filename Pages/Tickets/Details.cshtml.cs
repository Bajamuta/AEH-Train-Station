using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TrainStation.Pages.Tickets
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

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journey = await _context.Journeys
                    .Include(j => j.DestinationPlace)
                    .Include(j => j.Ride)
                    .Include(j => j.StartingPlace)
                    .Include(j => j.Status)
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

            return Page();
        }
    }
}