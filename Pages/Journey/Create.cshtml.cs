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
        ViewData["DayId"] = new SelectList(_context.Days, "ID", "ID");
        ViewData["DestinationPlaceId"] = new SelectList(_context.Places, "ID", "ID");
        ViewData["RideId"] = new SelectList(_context.Rides, "ID", "ID");
        ViewData["StartingPlaceId"] = new SelectList(_context.Places, "ID", "ID");
        ViewData["StatusId"] = new SelectList(_context.Statuses, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Models.Journey Journey { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Journeys.Add(Journey);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
