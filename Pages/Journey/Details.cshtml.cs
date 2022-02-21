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
        public List<Models.Car> TempCars { get; set; }
        public ICollection<Models.Cars> AllCarsInJourney { get; set; }
        public List<Ticket> AllTicketsInJourney { get; set; }
        public List<Models.TypeOfTicket> TypeOfTickets { get; set; }
        public List<TempCar> ListTempCars { get; set; }

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
                .Include(j => j.Tickets)
                .AsSplitQuery()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Journey == null)
            {
                return NotFound();
            }
            
            Ride = await _context.Rides
                .Include(d => d.Driver)
                .Include(d => d.Cars)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.Tickets)
                .Include(d => d.Conductors)
                .ThenInclude(c => c.ConductorEmployee)
                .Include(d => d.Engine)
                .AsSplitQuery()
                .FirstOrDefaultAsync(r => r.ID == Journey.RideId);
            
            AllCarsInJourney = await _context.Journeys
                .Include(j => j.Ride)
                .ThenInclude(r => r.Cars)
                .ThenInclude(r => r.Car)
                .Include(j => j.Tickets)
                .ThenInclude(t => t.Ticket)
                .Where(j => j.ID == id)
                .Select(j => j.Ride.Cars)
                .AsSplitQuery()
                .FirstAsync();

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
            
            AllTicketsInJourney = await _context.Tickets
                .Include(t => t.Journey)
                .ThenInclude(j => j.Ride)
                .Include(t => t.Ticket)
                .Where(j => j.Journey.RideId == Journey.RideId)
                .Select(t => t.Ticket)
                .ToListAsync();

            TypeOfTickets = await _context.TypesOfTickets
                .Include(t => t.Tickets)
                .ToListAsync();

            ListTempCars = new List<TempCar>();

            foreach (Models.Cars c in AllCarsInJourney)
            {
                TypeOfTicket sittingType = _context.TypesOfTickets.FirstOrDefault(t => t.Name == "sitting");
                TypeOfTicket standingType = _context.TypesOfTickets.FirstOrDefault(t => t.Name == "standing");
                Models.Car car = _context.Car.Include(c => c.Tickets)
                    .FirstOrDefault(cc => cc.ID == c.CarID);
                List<Ticket> ticketsStanding = await _context.Tickets
                    .Include(t => t.Journey)
                    .Where(t => t.JourneyID == id)
                    .Include(t => t.Ticket)
                    .ThenInclude(t => t.Car)
                    .ThenInclude(c => c.Tickets)
                    .Select(t => t.Ticket)
                    .Where(t => t.CarID == car.ID)
                    .Where(t => t.TypeOfTicketID == standingType.ID)
                    .AsSplitQuery()
                    .ToListAsync();
                
                List<Ticket> ticketsSitting = await _context.Tickets
                    .Include(t => t.Journey)
                    .Where(t => t.JourneyID == id)
                    .Include(t => t.Ticket)
                    .ThenInclude(t => t.Car)
                    .ThenInclude(c => c.Tickets)
                    .Select(t => t.Ticket)
                    .Where(t => t.CarID == car.ID)
                    .Where(t => t.TypeOfTicketID == sittingType.ID)
                    .AsSplitQuery()
                    .ToListAsync();

                TempCar tempCar;
                try
                {
                    if (car != null)
                        tempCar = new TempCar
                        {
                            Id = car.ID,
                            Name = car.Name,
                            AllSitting = car.Sitting,
                            AllStanding = car.Standing,
                            LeftSitting = car.Sitting - ticketsSitting.Count,
                            LeftStanding = car.Standing - ticketsStanding.Count
                        };
                    else
                    {
                        tempCar = null;
                    }
                    ListTempCars.Add(tempCar);
                }
                catch (Exception e)
                {
                    throw new Exception("Error", e);
                }
                
            }

            return Page();
        }
    }
}
