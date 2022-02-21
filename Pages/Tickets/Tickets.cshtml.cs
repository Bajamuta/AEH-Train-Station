﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainStation.Models;

namespace TrainStation.Pages.Tickets
{
    public class Tickets : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public Tickets(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }
        
        public Models.Journey Journey { get; set; }
        [BindProperty] public Models.Ticket Ticket { get; set; }
        public SelectList ListJourneyCars { get; set; }
        public SelectList ListTypesOfTickets { get; set; }
        public ICollection<Models.Cars> AllCarsInJourney { get; set; }
        public List<Ticket> AllTicketsInJourney { get; set; }
        public List<Models.TypeOfTicket> TypeOfTickets { get; set; }
        public List<TempCar> ListTempCars { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Journey = await _context.Journeys
                .Include(j => j.Ride)
                .ThenInclude(r => r.Cars)
                .ThenInclude(c => c.Car)
                .Include(j => j.StartingPlace)
                .Include(j => j.DestinationPlace)
                .Include(j => j.Tickets)
                .ThenInclude(t => t.Ticket)
                .AsSplitQuery()
                .FirstOrDefaultAsync(j => j.ID == id);

            Ticket = new Ticket();

            if (Journey == null) return NotFound();

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

            try
            {
                ListJourneyCars = new SelectList(AllCarsInJourney, "Car.ID", "Car.Name");
                ListTypesOfTickets = new SelectList(TypeOfTickets, "ID", "Name");
            }
            catch (Exception e)
            {
                throw new Exception("Error", e);
            }

            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                /*_context.Attach(Ride).State = EntityState.Modified;
                await _context.SaveChangesAsync();*/
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JourneyExists(Journey.ID))
                    return NotFound();
                throw;
            }

            return RedirectToPage("./Index");
        }
        
        private bool JourneyExists(int id)
        {
            return _context.Journeys.Any(e => e.ID == id);
        }
        
    }
}