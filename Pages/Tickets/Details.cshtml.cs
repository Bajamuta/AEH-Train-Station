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
        public int NumberOfAllPlaces { get; set; }
        public int AvailableSittingPlaces { get; set; }
        public int AvailableStandingPlaces { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journey = await _context.Journeys
                    .Include(j => j.DestinationPlace)
                    .Include(j => j.Ride)
                    .ThenInclude(r => r.Cars)
                    .ThenInclude(c => c.Car)
                    .Include(j => j.Ride)
                    .ThenInclude(r => r.Conductors)
                    .ThenInclude(c => c.ConductorEmployee)
                    .Include(j => j.StartingPlace)
                    .Include(j => j.Status)
                    .AsSingleQuery()
                    .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Journey == null)
            {
                return NotFound();
            }

            /*Ride = await _context.Rides
                .Include(d => d.Driver)
                .Include(d => d.Cars)
                .ThenInclude(c => c.Car)
                .Include(d => d.Conductors)
                .Include(d => d.Engine)
                .AsSingleQuery()
                .FirstOrDefaultAsync(r => r.ID == Journey.RideId);*/

            NumberOfAllPlaces = 0;
            AvailableSittingPlaces = 0;
            AvailableStandingPlaces = 0;
            
            foreach (Models.Cars rideCar in Journey.Ride.Cars)
            {
                NumberOfAllPlaces += rideCar.Car.Sitting + rideCar.Car.Standing;
                AvailableSittingPlaces += rideCar.Car.Sitting;
                AvailableStandingPlaces += rideCar.Car.Standing;
            }

            return Page();
        }
    }
}