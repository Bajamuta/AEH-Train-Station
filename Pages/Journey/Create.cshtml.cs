using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrainStation.Data;
using TrainStation.Models;

namespace TrainStation.Pages.Journey
{
    public class CreateModel : PageModel
    {
        private readonly TrainStation.Data.TrainStationContext _context;

        public CreateModel(TrainStation.Data.TrainStationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DestinationPlaceId"] = new SelectList(_context.Places, "ID", "Name");
            ViewData["RideId"] = new SelectList(_context.Rides, "ID", "Name");
            ViewData["StartingPlaceId"] = new SelectList(_context.Places, "ID", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Models.Journey Journey { get; set; }
        
        [BindProperty]
        public int BreakTemp { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Journey.StatusId = _context.Statuses.FirstOrDefault(s => s.Name == "future").ID;
            Journey.StartingPlace = _context.Places.FirstOrDefault(p => p.ID == Journey.StartingPlaceId);
            Journey.DestinationPlace = _context.Places.FirstOrDefault(p => p.ID == Journey.DestinationPlaceId);
            try
            {
                Journey.BreakTimeOnStation = Journey.CalculateBreakTime(BreakTemp);
                Journey.FullTimeRide = Journey.CalculateFullTime();
                Journey.EndingDateTime = Journey.CalculateEndTime();
            }
            catch (Exception e)
            {
                throw new Exception("Error:", e);
            }

            _context.Journeys.Add(Journey);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
